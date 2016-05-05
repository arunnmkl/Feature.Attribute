using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Feature.Attributes.Models;
using Feature.Attributes.Utilities.Attributes;

namespace Feature.Attributes
{
	/// <summary>
	/// Used to authorize the feature in CarrierRate.
	/// </summary>
	public class FeatureAuthorization : IDisposable
	{
		/// <summary>
		/// The is authorize
		/// </summary>
		public bool IsAuthorize = false;

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureAuthorization" /> class.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="featureResource">The feature resource.</param>
		/// <param name="permission">The permission.</param>
		/// <param name="avoidException">if set to <c>true</c> [avoid exception].</param>
		public FeatureAuthorization(Type type, short featureResource, short? permission = null, bool avoidException = false)
			: this(type, (FeatureResource)featureResource, (ApplicationPermission?)permission, avoidException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureAuthorization" /> class.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="featureResource">The feature resource.</param>
		/// <param name="permission">The permission.</param>
		/// <param name="avoidException">if set to <c>true</c> [avoid exception].</param>
		public FeatureAuthorization(Type type, FeatureResource featureResource, ApplicationPermission? permission = null, bool avoidException = false)
		{
			FeatureAccess(type, featureResource, permission, avoidException);
		}

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				//// Dispose any managed objects
			}
		}

		/// <summary>
		/// Features the access.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="featureResource">The feature resource.</param>
		/// <param name="permission">The permission.</param>
		/// <param name="avoidException">if set to <c>true</c> [avoid exception].</param>
		/// <exception cref="System.FeatureAuthorizationException"></exception>
		private void FeatureAccess(Type type, FeatureResource featureResource, ApplicationPermission? permission = null, bool avoidException = false)
		{
			var accessPermissions = GetFeatureAccessPermissions(type, featureResource);
			if (accessPermissions != null && accessPermissions.Count > 0)
			{
				var lrAccess = new List<LogicalResourceAccessRule>();
				accessPermissions.Where(r => r.Value == true).ToList().ForEach((s) =>
				{
					if (permission.HasValue)
					{
						if (permission.Value == s.Key)
						{
							lrAccess.Add(new LogicalResourceAccessRule()
							{
								ResourceName = featureResource.ToString(),
								RequiredPermission = (int)s.Key
							});
						}
					}
					else
					{
						lrAccess.Add(new LogicalResourceAccessRule()
						{
							ResourceName = featureResource.ToString(),
							RequiredPermission = (int)s.Key
						});
					}
				});

				if (lrAccess.Count > 0)
				{
					this.IsAuthorize = true;
				}
				else
				{
					this.IsAuthorize = false;
					if (!avoidException)
					{
						throw new FeatureAuthorizationException(string.Format("Access Violation on {0} feature{1}.", (object)featureResource, permission.HasValue ? string.Format(" of {0} permission", permission.ToString()) : string.Empty));
					}
				}
			}

		}

		/// <summary>
		/// Gets the feature access permissions.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="featureResource">The feature resource.</param>
		/// <returns></returns>
		/// <exception cref="System.MissingMemberException"></exception>
		/// <exception cref="System.IndexOutOfRangeException"></exception>
		private IDictionary<ApplicationPermission, bool> GetFeatureAccessPermissions(Type type, FeatureResource featureResource)
		{
			PropertyInfo[] properties = type.GetProperties();
			MethodInfo[] faMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

			var filteredMethod = faMethods.Where((r) =>
			{
				var m = r.GetCustomAttributes(typeof(FeatureMethodAttribute), true).FirstOrDefault() as FeatureMethodAttribute;
				return r.IsDefined(typeof(FeatureMethodAttribute)) && m.FeatureResource == featureResource;
			}).Select(r => new
			{
				FeatureMethod = r,
				FeatureAttribute = r.GetCustomAttributes(typeof(FeatureMethodAttribute), true).FirstOrDefault() as FeatureMethodAttribute
			});

			var accessPermisssions = new Dictionary<ApplicationPermission, bool>();
			foreach (var item in filteredMethod)
			{
				if (item != null && item.FeatureAttribute.FeatureResource == featureResource)
				{
					var featureProperties = properties.Where(prop => Attribute.IsDefined(prop, typeof(FeaturePropertyAttribute)) && prop.GetCustomAttribute<FeaturePropertyAttribute>(false).FeatureType == item.FeatureAttribute.FeatureType);
					if (featureProperties == null || featureProperties.Count() == 0)
					{
						throw new MissingMemberException(string.Format("Feature property is not implemented for {0}.", item.FeatureAttribute.FeatureType.ToString()));
					}

					if (featureProperties.Count() > 1)
					{
						throw new IndexOutOfRangeException(string.Format("More than one feature property has implemented for {0}.", item.FeatureAttribute.FeatureType.ToString()));
					}

					var paramsInfo = item.FeatureMethod.GetParameters();

					int id = Convert.ToInt32(featureProperties.FirstOrDefault().GetValue(null));
					var access = (bool)item.FeatureMethod.Invoke(null, new object[] { id });
					foreach (var p in item.FeatureAttribute.Permissions)
					{
						if (accessPermisssions.ContainsKey(p))
						{
							if (accessPermisssions[p] && !access)
							{
								accessPermisssions[p] = access;
							}
						}
						else
						{
							accessPermisssions.Add(p, access);
						}
					}
				}
			}

			return accessPermisssions;
		}
	}
}

using System;

namespace Feature.Attributes.Utilities.Attributes
{
	/// <summary>
	/// 
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class FeatureMethodAttribute : Attribute
	{
		/// <summary>
		/// The _feature resource
		/// </summary>
		private FeatureResource _featureResource;

		/// <summary>
		/// The _permissions
		/// </summary>
		private ApplicationPermission[] _permissions;

		/// <summary>
		/// The _feature type
		/// </summary>
		private FeatureType _featureType;

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureMethodAttribute" /> class.
		/// </summary>
		/// <param name="featureResource">The feature resource.</param>
		/// <param name="featureType">Type of the feature.</param>
		/// <param name="permissions">The permissions.</param>
		public FeatureMethodAttribute(FeatureResource featureResource, FeatureType featureType, ApplicationPermission[] permissions)
		{
			this._featureResource = featureResource;
			this._featureType = featureType;
			this._permissions = permissions;
		}

		/// <summary>
		/// Gets the feature resource.
		/// </summary>
		/// <value>
		/// The feature resource.
		/// </value>
		public FeatureResource FeatureResource
		{
			get { return _featureResource; }
		}

		/// <summary>
		/// Gets the permissions.
		/// </summary>
		/// <value>
		/// The permissions.
		/// </value>
		public ApplicationPermission[] Permissions
		{
			get { return _permissions; }
		}

		/// <summary>
		/// Gets the type of the feature.
		/// </summary>
		/// <value>
		/// The type of the feature.
		/// </value>
		public FeatureType FeatureType
		{
			get { return _featureType; }
		}
	}
}

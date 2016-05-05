using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Feature.Attributes.Utilities.Attributes;

namespace Feature.Attributes.Utilities.Helper
{
	/// <summary>
	/// 
	/// </summary>
	public static class EnumHelper
	{
		/// <summary>
		/// Gets the feature permissions.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumElement">The enum element.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">Type ' + type.Name + ' is not an enum</exception>
		public static List<int> GetFeaturePermissions<T>(this T enumElement)
		{
			Type type = typeof(T);

			if (!IsEnumType(ref type))
			{
				throw new ArgumentException("Type '" + type.Name + "' is not an enum");
			}

			FieldInfo fi = type.GetField(enumElement.ToString(), BindingFlags.Public | BindingFlags.Static);

			if (fi != null)
			{
				var fpa = fi.GetCustomAttributes(typeof(FeaturePermissionAttribute), true) as FeaturePermissionAttribute[];
				if (fpa == null || fpa.Count() == 0)
				{
					return null;
				}
				else
				{
					var permissions = new List<int>();
					fpa.ToList().ForEach((p) =>
					{
						permissions.Add(p.Permission);
					});

					return permissions;
				}

			}

			return null;
		}

		/// <summary>
		/// Determines if a type is an enum type
		/// </summary>
		/// <param name="type">the type</param>
		/// <returns>
		/// true is type is an enum or an enum? type
		/// </returns>
		private static bool IsEnumType(ref Type type)
		{
			if (type != null)
			{
				if (type.IsEnum)
				{
					return true;
				}
				else
				{
					Type nullableType = Nullable.GetUnderlyingType(type);
					if (nullableType != null && nullableType.IsEnum)
					{
						type = nullableType;
						return true;
					}
				}
			}

			return false;
		}
	}
}

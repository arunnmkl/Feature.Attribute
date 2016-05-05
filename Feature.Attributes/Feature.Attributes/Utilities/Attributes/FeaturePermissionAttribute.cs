using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature.Attributes.Utilities.Attributes
{
	/// <summary>
	/// This attribute is used to represent a feature permission for a value in an enum.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
	public sealed class FeaturePermissionAttribute : Attribute
	{
		/// <summary>
		/// The _permission
		/// </summary>
		private short _permission;

		/// <summary>
		/// Initializes a new instance of the <see cref="FeaturePermissionAttribute"/> class.
		/// </summary>
		/// <param name="permission">The permission.</param>
		public FeaturePermissionAttribute(ApplicationPermission permission)
		{
			this._permission = (short)permission;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FeaturePermissionAttribute"/> class.
		/// </summary>
		/// <param name="permission">The permission.</param>
		public FeaturePermissionAttribute(short permission)
		{
			this._permission = permission;
		}

		/// <summary>
		/// Gets the permission.
		/// </summary>
		/// <value>
		/// The permission.
		/// </value>
		public short Permission
		{
			get { return _permission; }
		}

	}
}

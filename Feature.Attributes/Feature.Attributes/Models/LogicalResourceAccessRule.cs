using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feature.Attributes.Models
{
	/// <summary>
	/// 
	/// </summary>
	public class LogicalResourceAccessRule
	{
		/// <summary>
		/// Gets or sets the name of the resource.
		/// </summary>
		/// <value>
		/// The name of the resource.
		/// </value>
		public string ResourceName { get; set; }

		/// <summary>
		/// Gets or sets the required permission.
		/// </summary>
		/// <value>
		/// The required permission.
		/// </value>
		public Int32 RequiredPermission { get; set; }
	}
}

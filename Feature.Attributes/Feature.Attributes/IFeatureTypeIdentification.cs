using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Attributes
{
	/// <summary>
	/// 
	/// </summary>
	public interface IFeatureTypeIdentification
	{
		/// <summary>
		/// Gets the account unique identifier.
		/// </summary>
		/// <value>
		/// The account unique identifier.
		/// </value>
		[FeatureProperty(Attributes.FeatureType.Account)]
		int AccountID { get; }

		/// <summary>
		/// Gets the account user unique identifier.
		/// </summary>
		/// <value>
		/// The account user unique identifier.
		/// </value>
		[FeatureProperty(Attributes.FeatureType.AccountUser)]
		int AccountUserID { get; }

		/// <summary>
		/// Gets the agency user unique identifier.
		/// </summary>
		/// <value>
		/// The agency user unique identifier.
		/// </value>
		[FeatureProperty(Attributes.FeatureType.AgencyUser)]
		int AgencyUserID { get; }
	}
}

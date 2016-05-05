using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feature.Attributes.Utilities.Attributes;

namespace Feature.Attributes
{
	/// <summary>
	/// Identification for feature resources
	/// </summary>
	public enum FeatureResource
	{
		/// <summary>
		/// The expedited
		/// </summary>
		[FeaturePermission(ApplicationPermission.Create)]
		[FeaturePermission(ApplicationPermission.Read)]
		Expedited,

		/// <summary>
		/// The hide charges
		/// </summary>
		HideCharges,

		/// <summary>
		/// The inflation rate
		/// </summary>
		InflationRate,

		/// <summary>
		/// The consolidate shipment
		/// </summary>
		ConsolidateShipment,

		/// <summary>
		/// The consolidation hub
		/// </summary>
		ConsolidationHub,

		/// <summary>
		/// The impersonated
		/// </summary>
		Impersonated
	}

	/// <summary>
	/// Identification for the feature type[as Account, Customer, AcgsecUser] level
	/// </summary>
	public enum FeatureType
	{
		/// <summary>
		/// The none
		/// </summary>
		None,

		/// <summary>
		/// The account / company
		/// </summary>
		Account,

		/// <summary>
		/// The account user / customer
		/// </summary>
		AccountUser,

		/// <summary>
		/// The agency user / legacy sales rep
		/// </summary>
		AgencyUser,

		/// <summary>
		/// The agency / partner company
		/// </summary>
		Agency,

		/// <summary>
		/// The acgsec user
		/// </summary>
		AcgsecUser
	}

	/// <summary>
	/// Defines a list of permissions
	/// </summary>
	public enum ApplicationPermission
	{
		/// <summary>
		/// No permission
		/// </summary>
		None = 0,

		/// <summary>
		/// Create permission
		/// </summary>
		Create = -1,

		/// <summary>
		/// Read permission
		/// </summary>
		Read = -2,

		/// <summary>
		/// Update permission
		/// </summary>
		Update = -3,

		/// <summary>
		/// Delete permission
		/// </summary>
		Delete = -4,

		/// <summary>
		/// Permission to assign permissions
		/// </summary>
		Delegate = -5,

		/// <summary>
		/// The impersonate
		/// </summary>
		Impersonate = -6
	}
}

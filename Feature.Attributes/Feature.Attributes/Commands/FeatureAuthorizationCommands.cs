using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feature.Attributes.Utilities.Attributes;

namespace Feature.Attributes.Commands
{
	/// <summary>
	/// Used to map feature authorization methods to their resource.
	/// </summary>
	public static class FeatureAuthorizationCommands
	{
		/// <summary>
		/// Gets the account unique identifier.
		/// </summary>
		/// <value>
		/// The account unique identifier.
		/// </value>
		[FeatureProperty(FeatureType.Account)]
		public static int AccountID
		{
			get
			{
				var r = new Random(); return r.Next(33333 * 3);
			}
		}

		/// <summary>
		/// Gets the account user unique identifier.
		/// </summary>
		/// <value>
		/// The account user unique identifier.
		/// </value>
		[FeatureProperty(FeatureType.AccountUser)]
		public static int AccountUserID
		{
			get
			{
				var r = new Random(); return r.Next(99956 * 3);
			}
		}

		/// <summary>
		/// Gets the agency user unique identifier.
		/// </summary>
		/// <value>
		/// The agency user unique identifier.
		/// </value>
		[FeatureProperty(FeatureType.AgencyUser)]
		public static int AgencyUserID
		{
			get
			{
				var r = new Random(); return r.Next(4564 * 3);
			}
		}

		/// <summary>
		/// Checks the has expedited access.
		/// </summary>
		/// <param name="accountUserId">The account user unique identifier.</param>
		/// <returns>
		/// true or false
		/// </returns>
		[FeatureMethod(FeatureResource.Expedited, FeatureType.Account, new ApplicationPermission[] { ApplicationPermission.Create, ApplicationPermission.Read })]
		public static bool CheckHasExpeditedAccess(int accountUserId)
		{
			return getAccess(accountUserId);
		}

		/// <summary>
		/// Checks the hide charges access.
		/// </summary>
		/// <param name="accountUserId">The account user identifier.</param>
		/// <returns>access permission</returns>
		[FeatureMethod(FeatureResource.HideCharges, FeatureType.AccountUser, new ApplicationPermission[] { ApplicationPermission.Read })]
		public static bool CheckHideChargesAccess(int accountUserId)
		{
			return getAccess(accountUserId);
		}

		/// <summary>
		/// Determines whether [has inflation rate] [the specified account user identifier].
		/// </summary>
		/// <param name="accountUserId">The account user identifier.</param>
		/// <returns>inflation rate access permission</returns>
		[FeatureMethod(FeatureResource.InflationRate, FeatureType.Account, new ApplicationPermission[] { ApplicationPermission.Read })]
		public static bool HasInflationRate(int accountUserId)
		{
			return getAccess(accountUserId);
		}

		/// <summary>
		/// Gets the access.
		/// </summary>
		/// <param name="accountUserId">The account user unique identifier.</param>
		/// <returns>the access</returns>
		private static bool getAccess(int accountUserId)
		{
			bool hasAccess = false;
			Random r = new Random();
			hasAccess = (r.Next(accountUserId * 3) % 3 == 0);
			return hasAccess;
		}
	}
}

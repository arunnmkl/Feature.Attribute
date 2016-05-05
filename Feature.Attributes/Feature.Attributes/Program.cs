using System;
using System.Linq;
using Feature.Attributes.Commands;
using Feature.Attributes.Utilities.Helper;

namespace Feature.Attributes
{
	/// <summary>
	/// 
	/// </summary>
	class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		static void Main(string[] args)
		{
			try
			{
				using (var fa = new FeatureAuthorization(typeof(FeatureAuthorizationCommands), FeatureResource.Expedited, ApplicationPermission.Update))
				{
					Console.WriteLine(string.Format("\nResource name {0} has {1} permission.", FeatureResource.Expedited, ApplicationPermission.Update));
				}
			}
			catch (FeatureAuthorizationException avex)
			{
				Console.WriteLine(string.Format("\n{0}", avex.Message));
			}

			try
			{
				using (var fa = new FeatureAuthorization(typeof(FeatureAuthorizationCommands), FeatureResource.HideCharges, ApplicationPermission.Read))
				{
					Console.WriteLine(string.Format("\nResource name {0} has {1} permission.", FeatureResource.HideCharges, ApplicationPermission.Read));
				}
			}
			catch (FeatureAuthorizationException avex)
			{
				Console.WriteLine(string.Format("\n{0}", avex.Message));
			}

			try
			{
				using (var fa = new FeatureAuthorization(typeof(FeatureAuthorizationCommands), FeatureResource.InflationRate))
				{
					Console.WriteLine(string.Format("\nResource name {0} has permission.", FeatureResource.InflationRate));
				}
			}
			catch (FeatureAuthorizationException avex)
			{
				Console.WriteLine(string.Format("\n{0}", avex.Message));
			}

			using (var fa = new FeatureAuthorization(typeof(FeatureAuthorizationCommands), (short)FeatureResource.Expedited, (short)ApplicationPermission.Create, avoidException: true))
			{
				if (fa.IsAuthorize)
				{
					Console.WriteLine(string.Format("\nResource name {0} has {1} permission.", FeatureResource.Expedited, ApplicationPermission.Create));
				}
				else
				{
					Console.WriteLine("\nNot Authorize.");
				}
			}

			Console.ReadLine();
		}
	}
}

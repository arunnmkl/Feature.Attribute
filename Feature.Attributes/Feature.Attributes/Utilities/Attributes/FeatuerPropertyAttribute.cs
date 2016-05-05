using System;

namespace Feature.Attributes.Utilities.Attributes
{
	/// <summary>
	/// 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class FeaturePropertyAttribute : Attribute
	{
		/// <summary>
		/// The _feature type
		/// </summary>
		private FeatureType _featureType;

		/// <summary>
		/// Initializes a new instance of the <see cref="FeaturePropertyAttribute"/> class.
		/// </summary>
		/// <param name="featureType">Type of the feature.</param>
		public FeaturePropertyAttribute(FeatureType featureType)
		{
			this._featureType = featureType;
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

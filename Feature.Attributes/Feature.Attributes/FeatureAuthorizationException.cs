using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Feature.Attributes
{
	/// <summary>
	/// The class to encapsulate and transport a feature authorization exception
	/// </summary>
	[Serializable]
	public class FeatureAuthorizationException : AccessViolationException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureAuthorizationException" /> class.
		/// </summary>
		public FeatureAuthorizationException()
		{
			// Add any type-specific logic, and supply the default message.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureAuthorizationException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public FeatureAuthorizationException(string message)
			: base(message)
		{
			// Add any type-specific logic.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureAuthorizationException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public FeatureAuthorizationException(string message, Exception innerException) :
			base(message, innerException)
		{
			// Add any type-specific logic for inner exceptions.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureAuthorizationException" /> class.
		/// </summary>
		/// <param name="info">The information.</param>
		/// <param name="context">The context.</param>
		protected FeatureAuthorizationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			// Implement type-specific serialization constructor logic.
		}
	}
}

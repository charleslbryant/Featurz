namespace Featurz.Core.Manager
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Featurz.DomainModel;

	//https://github.com/togglz/togglz/blob/master/core/src/main/java/org/togglz/core/manager/FeatureManager.java
	/// <summary>
	/// The FeatureManager is the central class in Featurz. It's typically obtained using
	/// FeatureContext.GetFeatureManager().
	/// </summary>
	public interface IFeatureManager
	{
		/// <summary>
		/// Gets the name of the feature manager.
		/// </summary>
		/// <value>
		/// The name of the feature manager.
		/// </value>
		string FeatureManagerName { get; }
		
		/// <summary>
		/// Gets a list of all the Features under management.
		/// </summary>
		/// <value>
		/// IList of Features should never be null.
		/// </value>
		IList<Feature> Features { get; }

		/// <summary>
		/// Gets the current FeatureUser. This method will internally use the configured {@link UserProvider} to obtain the user.
		/// </summary>
		/// <value>
		/// The current FeatureUser.
		/// </value>
		FeatureUser CurrentFeatureUser { get; }

		/// <summary>
		/// Gets the meta data for the specified Feture.
		/// </summary>
		/// <param name="feature">The Feature.</param>
		/// <returns>The IFeatureMetaData for the Feature.</returns>
		IFeatureMetaData GetMetaData(Feature feature);
		
		/// <summary>
		/// Determines whether [is active] [the specified Feature].
		/// </summary>
		/// <param name="feature">The Feature.</param>
		/// <returns>
		///   <c>true</c> if [is active] [the specified Feature]; otherwise, <c>false</c>.
		/// </returns>
		bool IsActive(Feature feature);

		/// <summary>
		/// Gets the state of the specified Feature. This state represents the current configuration of the
		/// feature and is typically persisted by a StateRepository across application restarts. The state includes whether
		/// the feature is enabled or disabled and the use list.
		/// </summary>
		/// <param name="feature">The Feature.</param>
		/// <returns>The current state of the Feature, never null.</returns>
		FeatureState GetFeatureState(Feature feature);
		
		/// <summary>
		/// Sets the state of the feature. This allows clients to enable or disable a Feature and to modify the user list associated with
		/// the Feature.
		/// </summary>
		/// <param name="feature">The FeatureState.</param>
		void SetFeatureState(FeatureState feature);
	}
}

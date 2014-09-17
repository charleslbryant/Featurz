namespace Featurz.Application.QueryResult.Feature
{
	using System;
	using Archer.Core.Query;

	public class IsFeatureActiveQueryResult : IQueryResult
	{
		public IsFeatureActiveQueryResult(bool isFeatureActive)
		{
			this.IsFeatureActive = isFeatureActive;
		}

		public bool IsFeatureActive { get; private set; }
	}
}
namespace Featurz.Application.Query
{
	using System;
	using Archer.Core.Query;

	public class IsFeatureActiveQuery : IQuery
	{
		public IsFeatureActiveQuery(string featureId)
		{
			this.FeatureId = featureId;
		}

		public string FeatureId { get; private set; }
	}
}
namespace Featurz.Application.QueryResult.Feature
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;

	public class GetFeaturesQueryResult : IQueryResult
	{
		public GetFeaturesQueryResult(ICollection<Feature> features)
		{
			this.Features = features;
		}

		public ICollection<Feature> Features { get; private set; }
	}
}
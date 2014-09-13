namespace Featurz
{
	using System;
	using Archer.Core.Query;
	using Featurz.Application.Entity;
	using Featurz.Application.Query;
	using Featurz.Application.QueryHandler;
	using Featurz.Application.QueryResult;

	public static class Flag
	{
		public static bool IsActive(string featureId, IQueryHandler<IsFeatureActiveQuery, IsFeatureActiveQueryResult, Feature> handler = null)
		{
			if (string.IsNullOrWhiteSpace(featureId))
			{
				throw new ArgumentException("featureId must not be a null value.");
			}

			IsFeatureActiveQuery query = new IsFeatureActiveQuery(featureId);

			if (handler == null)
			{
				handler = new IsFeatureActiveQueryHandler();
			}

			IsFeatureActiveQueryResult result = handler.Retrieve(query);

			return result.IsFeatureActive;
		}
	}
}
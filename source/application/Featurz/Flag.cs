namespace Featurz
{
	using System;
	using Archer.Core.Query;
	using Archer.Core.Repository;
	using Archer.Infrastructure.Configuration;
	using Archer.Infrastructure.Data.MongoDb;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.Feature;
	using Featurz.Application.QueryHandler;
	using Featurz.Application.QueryResult.Feature;

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
				handler.Config = new AppConfig();
				IReadRepository<Feature> read = new MongoReadRepository<Feature>();
				read.Initialize(handler.Config);
				IWriteRepository<Feature> write = new MongoWriteRepository<Feature>();
				write.Initialize(handler.Config);
				handler.ReadRepository = read;
				handler.WriteRepository = write;
			}

			IsFeatureActiveQueryResult result = handler.Retrieve(query);

			return result.IsFeatureActive;
		}
	}
}
namespace Featurz.Application.QueryHandler
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Query;
	using Archer.Core.Repository;
	using Archer.Infrastructure.Configuration;
	using Archer.Infrastructure.Data.MongoDb;
	using Featurz.Application.Entity;
	using Featurz.Application.Query;
	using Featurz.Application.QueryResult;

	public class IsFeatureActiveQueryHandler : IQueryHandler<IsFeatureActiveQuery, IsFeatureActiveQueryResult>
	{
		private readonly IReadRepository<Feature> featureRepo;
		private readonly IReadRepository<FeatureUser> userRepo;
		private IConfiguration config;

		public IsFeatureActiveQueryHandler(IReadRepository<Feature> featureRepo, IReadRepository<FeatureUser> userRepo)
		{
			this.featureRepo = featureRepo;
			this.userRepo = userRepo;
		}

		public IsFeatureActiveQueryHandler()
		{
			this.config = new AppConfig();
			this.userRepo = new MongoReadRepository<FeatureUser>(config);
			this.featureRepo = new MongoReadRepository<Feature>(config);
		}

		public IsFeatureActiveQueryResult Retrieve(IsFeatureActiveQuery query)
		{
			Feature feature = this.featureRepo.GetById(query.FeatureId);
			IsFeatureActiveQueryResult result = new IsFeatureActiveQueryResult(feature.IsActive);
			return result;
		}

		private bool IsActive(Feature feature)
		{
			if (!feature.IsEnabled)
			{
				return false;
			}

			int strategyId = feature.StrategyId;

			if (strategyId == default(int))
			{
				return true;
			}

			FeatureUser user = userRepo.GetById("");

			//ICollection<IFeatureActivationStrategy> strategies = featureProvider.GetFeatureActivationStrategies(feature.Id);
			//Somehow we have to get the activation strategy implementation
			//foreach (IFeatureActivationStrategy strategy in strategies)
			//{
			//	if (strategy.Id == strategyId)
			//	{
			//		return strategy.IsActive(feature, user);
			//	}
			//}

			return true;
		}
	}
}
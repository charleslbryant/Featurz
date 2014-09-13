namespace Featurz.Application.QueryHandler
{
	using System;
	using Archer.Core.Query;
	using Featurz.Application.Entity;
	using Featurz.Application.Query;
	using Featurz.Application.QueryResult;

	public class IsFeatureActiveQueryHandler : BaseQueryHandler<Feature>, IQueryHandler<IsFeatureActiveQuery, IsFeatureActiveQueryResult, Feature>
	{
		public IsFeatureActiveQueryHandler()
		{
		}

		public IsFeatureActiveQueryResult Retrieve(IsFeatureActiveQuery query)
		{
			Feature feature = this.ReadRepository.GetById(query.FeatureId);
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

			//FeatureUser user = GetUserByIdQueryHandler().retrieve("");

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
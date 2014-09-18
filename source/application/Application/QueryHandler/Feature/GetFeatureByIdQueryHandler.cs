namespace Featurz.Application.QueryHandler.Feature
{
	using System;
	using Archer.Core.Query;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.Feature;
	using Featurz.Application.QueryResult.Feature;

	public class GetFeatureByIdQueryHandler : BaseQueryHandler<Feature>, IQueryHandler<GetFeatureByIdQuery, GetFeatureQueryResult, Feature>
	{
		public GetFeatureByIdQueryHandler()
			: base()
		{
		}

		public GetFeatureQueryResult Retrieve(GetFeatureByIdQuery query)
		{
			Feature feature = this.ReadRepository.GetById(query.FeatureId);
			GetFeatureQueryResult result = new GetFeatureQueryResult(feature.Id, feature.Name, feature.UserId, feature.Ticket, feature.IsActive, feature.IsEnabled, feature.StrategyId);
			return result;
		}
	}
}
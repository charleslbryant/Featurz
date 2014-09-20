namespace Featurz.Application.QueryHandler.Feature
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.Feature;
	using Featurz.Application.QueryResult.Feature;

	public class GetFeaturesQueryHandler : BaseQueryHandler<Feature>, IQueryHandler<GetFeaturesQuery, GetFeaturesQueryResult, Feature>
	{
		public GetFeaturesQueryHandler()
			: base()
		{
		}

		public GetFeaturesQueryResult Retrieve(GetFeaturesQuery query)
		{
			//TODO: Change to pageable query
			ICollection<Feature> features = this.ReadRepository.All();
			//ICollection<Feature> features = this.GetFeaturesMock(query);
			GetFeaturesQueryResult result = new GetFeaturesQueryResult(features);
			return result;
		}

		private ICollection<Feature> GetFeaturesMock(GetFeaturesQuery query)
		{
			List<Feature> features = new List<Feature>();
			int count = query.PageSize * 2 + 3;

			if (count < 1)
			{
				return features;
			}

			DateTime date = DateTime.Now;

			for (int i = 1; i < count; i++)
			{
				Feature feature = new Feature(i.ToString(), date, "Feature " + i.ToString(), "charles.bryant", i.ToString(), i < 3 || i == 7);

				features.Add(feature);
			}

			return features;
		}
	}
}
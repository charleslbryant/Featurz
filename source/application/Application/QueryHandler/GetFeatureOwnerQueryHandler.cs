namespace Featurz.Application.QueryHandler
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;
	using Featurz.Application.Query;
	using Featurz.Application.QueryResult;

	public class GetFeatureOwnerQueryHandler : BaseQueryHandler<User>, IQueryHandler<GetFeatureOwnersQuery, GetFeatureOwnersQueryResult, User>
	{
		public GetFeatureOwnerQueryHandler()
		{
		}

		public GetFeatureOwnersQueryResult Retrieve(GetFeatureOwnersQuery query)
		{
			//TODO: Change to pageable query
			ICollection<User> users = this.ReadRepository.All();
			//ICollection<Feature> features = this.GetFeaturesMock(query);
			GetFeatureOwnersQueryResult result = new GetFeatureOwnersQueryResult(users);
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

			for (int i = 1; i < count; i++)
			{
				Feature feature = new Feature(i.ToString(), "Feature " + i.ToString(), "charles.bryant", i.ToString(), i < 3 || i == 7);

				features.Add(feature);
			}

			return features;
		}
	}
}
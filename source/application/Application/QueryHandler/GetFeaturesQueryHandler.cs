namespace Featurz.Application.QueryHandler
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Configuration;
	using Archer.Core.Query;
	using Archer.Core.Repository;
	using Archer.Infrastructure.Configuration;
	using Archer.Infrastructure.Data.MongoDb;
	using Featurz.Application.Entity;
	using Featurz.Application.Query;
	using Featurz.Application.QueryResult;

	public class GetFeaturesQueryHandler : IQueryHandler<GetFeaturesQuery, GetFeaturesQueryResult, Feature>
	{
		public GetFeaturesQueryHandler()
		{
		}

		public IConfiguration Config { get; set; }

		public IReadRepository<Feature> ReadRepository { get; set; }

		public IWriteRepository<Feature> WriteRepository { get; set; }

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

			for (int i = 1; i < count; i++)
			{
				Feature feature = new Feature(i.ToString(), "Feature " + i.ToString(), "charles.bryant", i.ToString(), i < 3 || i == 7);

				features.Add(feature);
			}

			return features;
		}
	}
}
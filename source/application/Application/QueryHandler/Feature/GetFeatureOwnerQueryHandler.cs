namespace Featurz.Application.QueryHandler.Feature
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.Feature;
	using Featurz.Application.QueryResult.Feature;

	public class GetFeatureOwnerQueryHandler : BaseQueryHandler<User>, IQueryHandler<GetFeatureOwnersQuery, GetFeatureOwnersQueryResult, User>
	{
		public GetFeatureOwnerQueryHandler()
			: base()
		{
		}

		public GetFeatureOwnersQueryResult Retrieve(GetFeatureOwnersQuery query)
		{
			//TODO: Change to pageable query
			//ICollection<User> users = this.ReadRepository.All();
			ICollection<User> users = this.GetUsersMock(query);
			GetFeatureOwnersQueryResult result = new GetFeatureOwnersQueryResult(users);
			return result;
		}

		private ICollection<User> GetUsersMock(GetFeatureOwnersQuery query)
		{
			List<User> users = new List<User>();
			int count = query.PageSize * 2 + 3;

			if (count < 1)
			{
				return users;
			}

			DateTime date = DateTime.Now;

			for (int i = 1; i < count; i++)
			{
				User user = new User("Tester" + i.ToString(), date, "tester" + i.ToString() + "abc.comx", "Tester" + i.ToString(), "Master" + i.ToString(), new List<string>() { "admin", "user" }, new List<string>() { }, true);

				users.Add(user);
			}

			return users;
		}
	}
}
namespace Featurz.Application.QueryHandler.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.User;
	using Featurz.Application.QueryResult.User;

	public class GetUsersQueryHandler : BaseQueryHandler<User>, IQueryHandler<GetUsersQuery, GetUsersQueryResult, User>
	{
		public GetUsersQueryHandler()
			: base()
		{
		}

		public GetUsersQueryResult Retrieve(GetUsersQuery query)
		{
			//TODO: Change to pageable query
			ICollection<User> users = this.ReadRepository.All();
			//ICollection<User> users = this.GetUsersMock(query);
			GetUsersQueryResult result = new GetUsersQueryResult(users);
			return result;
		}

		private ICollection<User> GetUsersMock(GetUsersQuery query)
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
				User user = new User(i.ToString(), date, "User " + i.ToString() + "@abc.comx", "FirstName" + i.ToString(), "LastName" + i.ToString(), null, null, i < 3 || i == 7);

				users.Add(user);
			}

			return users;
		}
	}
}
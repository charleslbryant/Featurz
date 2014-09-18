namespace Featurz.Application.QueryHandler.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.User;
	using Featurz.Application.QueryResult.User;

	public class GetUserRolesQueryHandler : BaseQueryHandler<User>, IQueryHandler<GetUserRolesQuery, GetUserRolesQueryResult, User>
	{
		public GetUserRolesQueryHandler()
			: base()
		{
		}

		public GetUserRolesQueryResult Retrieve(GetUserRolesQuery query)
		{
			//TODO: Change to pageable query
			//ICollection<Role> groups = this.ReadRepository.All();
			ICollection<Role> groups = this.GetRolesMock(query);
			GetUserRolesQueryResult result = new GetUserRolesQueryResult(groups);
			return result;
		}

		private ICollection<Role> GetRolesMock(GetUserRolesQuery query)
		{
			List<Role> groups = new List<Role>();
			int count = query.PageSize * 2 + 3;

			if (count < 1)
			{
				return groups;
			}

			for (int i = 1; i < count; i++)
			{
				Role group = new Role(i.ToString(), "Role" + i.ToString());

				groups.Add(group);
			}

			return groups;
		}
	}
}
namespace Featurz.Application.QueryHandler.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.User;
	using Featurz.Application.QueryResult.User;

	public class GetUserGroupsQueryHandler : BaseQueryHandler<User>, IQueryHandler<GetUserGroupsQuery, GetUserGroupsQueryResult, User>
	{
		public GetUserGroupsQueryHandler()
			: base()
		{
		}

		public GetUserGroupsQueryResult Retrieve(GetUserGroupsQuery query)
		{
			//TODO: Change to pageable query
			//ICollection<Group> groups = this.ReadRepository.All();
			ICollection<Group> groups = this.GetGroupsMock(query);
			GetUserGroupsQueryResult result = new GetUserGroupsQueryResult(groups);
			return result;
		}

		private ICollection<Group> GetGroupsMock(GetUserGroupsQuery query)
		{
			List<Group> groups = new List<Group>();
			int count = query.PageSize * 2 + 3;

			if (count < 1)
			{
				return groups;
			}

			for (int i = 1; i < count; i++)
			{
				Group group = new Group(i.ToString(), "Group" + i.ToString(), new List<Role>(){new Role("1", "admin")});

				groups.Add(group);
			}

			return groups;
		}
	}
}
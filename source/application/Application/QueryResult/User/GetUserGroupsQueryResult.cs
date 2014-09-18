namespace Featurz.Application.QueryResult.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;

	public class GetUserGroupsQueryResult : IQueryResult
	{
		public GetUserGroupsQueryResult(ICollection<Group> groups)
		{
			this.UserGroups = groups;
		}

		public IEnumerable<Group> UserGroups { get; set; }
	}
}
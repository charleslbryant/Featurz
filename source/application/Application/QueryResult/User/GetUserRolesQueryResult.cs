namespace Featurz.Application.QueryResult.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;

	public class GetUserRolesQueryResult : IQueryResult
	{
		public GetUserRolesQueryResult(ICollection<Role> users)
		{
			this.UserRoles = users;
		}

		public IEnumerable<Role> UserRoles { get; set; }
	}
}
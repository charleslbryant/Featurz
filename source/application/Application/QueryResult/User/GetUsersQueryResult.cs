namespace Featurz.Application.QueryResult.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;

	public class GetUsersQueryResult : IQueryResult
	{
		public GetUsersQueryResult(ICollection<User> users)
		{
			this.Users = users;
		}

		public ICollection<User> Users { get; private set; }
	}
}
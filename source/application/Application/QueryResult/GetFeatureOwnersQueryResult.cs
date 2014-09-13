namespace Featurz.Application.QueryResult
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;
	using Featurz.Application.Entity;

	public class GetFeatureOwnersQueryResult : IQueryResult
	{
		public GetFeatureOwnersQueryResult(ICollection<User> users)
		{
			this.Owners = users;
		}

		public IEnumerable<User> Owners { get; set; }
	}
}
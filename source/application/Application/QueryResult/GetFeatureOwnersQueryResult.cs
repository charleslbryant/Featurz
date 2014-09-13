namespace Featurz.Application.QueryResult
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;

	public class GetFeatureOwnersQueryResult : IQueryResult
	{
		public IEnumerable<string> Owners { get; set; }
	}
}
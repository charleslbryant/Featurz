namespace Featurz.Application.Query.User
{
	using System;
	using Archer.Core.Entity;
	using Archer.Core.Query;

	public class GetUserGroupsQuery : PageableQuery
	{
		public GetUserGroupsQuery(int pageSize, int page, string sortColumn, SortDirection sortDirection)
			: base(pageSize, page, sortColumn, sortDirection)
		{
		}
	}
}
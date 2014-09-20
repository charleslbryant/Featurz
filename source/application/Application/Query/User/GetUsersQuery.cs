namespace Featurz.Application.Query.User
{
	using System;
	using Archer.Core.Entity;

	public class GetUsersQuery : PageableQuery
	{
		public GetUsersQuery(int pageSize, int page, string sortColumn, SortDirection sortDirection)
			: base(pageSize, page, sortColumn, sortDirection)
		{
		}
	}
}
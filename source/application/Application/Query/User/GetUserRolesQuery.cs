namespace Featurz.Application.Query.User
{
	using System;
	using Archer.Core.Entity;

	public class GetUserRolesQuery : PageableQuery
	{
		public GetUserRolesQuery(int pageSize, int page, string sortColumn, SortDirection sortDirection)
			: base(pageSize, page, sortColumn, sortDirection)
		{
		}
	}
}
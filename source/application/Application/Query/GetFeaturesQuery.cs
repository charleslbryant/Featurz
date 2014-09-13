namespace Featurz.Application.Query
{
	using System;
	using Archer.Core.Entity;

	public class GetFeaturesQuery : PageableQuery
	{
		public GetFeaturesQuery(int pageSize, int page, string sortColumn, SortDirection sortDirection)
			: base(pageSize, page, sortColumn, sortDirection)
		{
		}
	}
}
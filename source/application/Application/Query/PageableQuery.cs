namespace Featurz.Application.Query
{
	using System;
	using Archer.Core.Entity;
	using Archer.Core.Query;

	public class PageableQuery : IQuery
	{
		public PageableQuery(int pageSize, int page, string sortColumn, SortDirection sortDirection)
		{
			this.PageSize = pageSize;
			this.Page = page;
			this.SortColumn = sortColumn;
			this.SortDirection = sortDirection;
		}

		public string SortColumn { get; private set; }
		public SortDirection SortDirection { get; private set; }
		public int PageSize { get; private set; }
		public int Page { get; private set; }
	}
}
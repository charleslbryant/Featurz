namespace Archer.Core.Query
{
	using System;
	using Archer.Core.Entity;

	public interface IQueryDispatcher
	{
		TResult Dispatch<TParameter, TResult, TEntity>(TParameter query)
			where TParameter : IQuery
			where TResult : IQueryResult
			where TEntity : IEntity;
	}
}
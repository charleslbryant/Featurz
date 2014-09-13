namespace Archer.Core.Query
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using Archer.Core.Repository;

	public interface IQueryHandler<in TParameter, out TResult, TEntity>
		where TResult : IQueryResult
		where TParameter : IQuery
		where TEntity : IEntity
	{
		IConfiguration Config { get; set; }

		IReadRepository<TEntity> ReadRepository { get; set; }

		IWriteRepository<TEntity> WriteRepository { get; set; }

		TResult Retrieve(TParameter query);
	}
}
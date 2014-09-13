namespace Archer.Core.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;

	public interface IReadRepository<TEntity> where TEntity : IEntity
	{
		IConfiguration Config { get; set; }

		IList<TEntity> All();

		TEntity GetById(string id);

		void Initialize(IConfiguration config);

		IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
	}
}
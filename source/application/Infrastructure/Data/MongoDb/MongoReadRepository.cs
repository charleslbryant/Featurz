namespace Archer.Infrastructure.Data.MongoDb
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using Archer.Core.Entity;
	using Archer.Core.Repository;
	using MongoDB.Driver.Linq;

	public class MongoReadRepository<TEntity> : MongoBase<TEntity>,
		IReadRepository<TEntity> where TEntity : EntityBase
	{
		public MongoReadRepository()
			: base()
		{
		}

		public IList<TEntity> All()
		{
			return this.Collection.FindAllAs<TEntity>().ToList();
		}

		public TEntity GetById(string id)
		{
			return this.Collection.FindOneByIdAs<TEntity>(id);
		}

		public IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
		{
			return this.Collection.AsQueryable<TEntity>().Where(predicate.Compile()).ToList();
		}
	}
}
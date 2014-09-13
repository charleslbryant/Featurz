namespace Archer.Infrastructure.Data.MongoDb
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using Archer.Core.Repository;
	using MongoDB.Driver.Linq;

	public class MongoReadRepository<TEntity> : MongoBase<TEntity>,
		IReadRepository<TEntity> where TEntity : EntityBase
	{
		private IConfiguration config;

		public MongoReadRepository()
			: base()
		{
		}

		public IConfiguration Config { get; set; }

		public void Initialize(IConfiguration config)
		{
			if (config == null)
			{
				throw new Exception("Config cannot be a null value.");
			}

			this.Config = config;

			base.Initialize(this.Config);
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
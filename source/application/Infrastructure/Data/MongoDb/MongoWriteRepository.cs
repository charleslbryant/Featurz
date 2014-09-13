namespace Archer.Infrastructure.Data.MongoDb
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using Archer.Core.Repository;

	public class MongoWriteRepository<TEntity> : MongoBase<TEntity>,
		IWriteRepository<TEntity> where TEntity : EntityBase
	{
		public MongoWriteRepository()
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

		public bool Delete(TEntity entity)
		{
			return this.Collection.Remove(MongoDB.Driver.Builders.Query.EQ("_id", entity.Id)).DocumentsAffected > 0;
		}

		public bool Insert(TEntity entity)
		{
			return this.Collection.Insert(entity).Ok;
		}

		public bool Update(TEntity entity)
		{
			if (entity.Id == null)
			{
				return this.Insert(entity);
			}

			return this.Collection.Save(entity).DocumentsAffected > 0;
		}
	}
}
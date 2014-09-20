namespace Archer.Infrastructure.Data.MongoDb
{
	using System;
	using Archer.Core.Entity;
	using Archer.Core.Exceptions;
	using Archer.Core.Repository;

	public class MongoWriteRepository<TEntity> : MongoBase<TEntity>,
		IWriteRepository<TEntity> where TEntity : EntityBase
	{
		public MongoWriteRepository()
			: base()
		{
		}

		public bool Delete(TEntity entity)
		{
			return this.Collection.Remove(MongoDB.Driver.Builders.Query.EQ("_id", entity.Id)).DocumentsAffected > 0;
		}

		public bool Insert(TEntity entity)
		{
			try
			{
				return this.Collection.Insert(entity).Ok;
			}
			catch (MongoDB.Driver.MongoDuplicateKeyException)
			{
				throw new DuplicateKeyException(string.Format("A document already exists with the Id {0}", entity.Id));
			}
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
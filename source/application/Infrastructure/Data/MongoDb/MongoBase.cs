namespace Archer.Infrastructure.Data.MongoDb
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using MongoDB.Driver;

	public abstract class MongoBase<TEntity> where TEntity : EntityBase
	{
		protected MongoBase()
		{
		}

		public IConfiguration Config { get; set; }

		protected MongoCollection<TEntity> Collection { get; set; }

		protected MongoDatabase Database { get; set; }

		public void Initialize(IConfiguration config)
		{
			if (config == null)
			{
				throw new Exception("Config cannot be a null value.");
			}

			this.Config = config;
			this.GetDatabase();
			this.GetCollection();
		}

		protected void GetCollection()
		{
			this.Collection = this.Database.GetCollection<TEntity>(typeof(TEntity).Name);
		}

		protected string GetConnectionString()
		{
			return this.Config.Get<string>("archer.db.connectionstring.mongo").Replace("{DB_NAME}", this.GetDatabaseName());
		}

		protected void GetDatabase()
		{
			var client = new MongoClient(this.GetConnectionString());
			var server = client.GetServer();

			this.Database = server.GetDatabase(this.GetDatabaseName());
		}

		protected string GetDatabaseName()
		{
			return this.Config.Get<string>("archer.db.name");
		}
	}
}
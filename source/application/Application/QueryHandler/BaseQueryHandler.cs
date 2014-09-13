namespace Featurz.Application.QueryHandler
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using Archer.Core.Repository;

	public class BaseQueryHandler<TEntity> where TEntity : IEntity
	{
		public IConfiguration Config { get; set; }

		public IReadRepository<TEntity> ReadRepository { get; set; }

		public IWriteRepository<TEntity> WriteRepository { get; set; }
	}
}
namespace Featurz.Application.CommandHandler
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using Archer.Core.Repository;

	public class BaseCommandHandler<TEntity> where TEntity : IEntity
	{
		public IConfiguration Config { get; set; }

		public IReadRepository<TEntity> ReadRepository { get; set; }

		public IWriteRepository<TEntity> WriteRepository { get; set; }
	}
}
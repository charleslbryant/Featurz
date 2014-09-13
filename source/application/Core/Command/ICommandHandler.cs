namespace Archer.Core.Command
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using Archer.Core.Repository;

	public interface ICommandHandler<in TParameter, TEntity> 
		where TParameter : ICommand
		where TEntity : IEntity
	{
		void Execute(TParameter command);
		IConfiguration Config { get; set; }

		IReadRepository<TEntity> ReadRepository { get; set; }

		IWriteRepository<TEntity> WriteRepository { get; set; }
	}
}
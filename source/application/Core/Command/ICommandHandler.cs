namespace Archer.Core.Command
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using Archer.Core.Repository;

	public interface ICommandHandler<in TParameter, out TResult, TEntity>
		where TParameter : ICommand
		where TResult : ICommandResult
		where TEntity : IEntity
	{
		IConfiguration Config { get; set; }

		IReadRepository<TEntity> ReadRepository { get; set; }

		IWriteRepository<TEntity> WriteRepository { get; set; }

		TResult Execute(TParameter command);
	}
}
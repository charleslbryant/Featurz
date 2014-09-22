namespace Archer.Core.Command
{
	using System;
	using Archer.Core.Entity;

	public interface ICommandDispatcher
	{
		TResult Dispatch<TParameter, TResult, TEntity>(TParameter command) 
			where TParameter : ICommand
			where TResult : ICommandResult
			where TEntity : IEntity;
	}
}
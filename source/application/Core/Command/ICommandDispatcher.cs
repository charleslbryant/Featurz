namespace Archer.Core.Command
{
	using System;
	using Archer.Core.Entity;

	public interface ICommandDispatcher
	{
		void Dispatch<TParameter, TEntity>(TParameter command) 
			where TParameter : ICommand
			where TEntity : IEntity;
	}
}
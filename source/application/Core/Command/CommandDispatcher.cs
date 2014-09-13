namespace Archer.Core.Command
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using Archer.Core.Repository;
	using Ninject;

	public class CommandDispatcher : ICommandDispatcher
	{
		private readonly IKernel kernel;

		public CommandDispatcher(IKernel kernel)
		{
			if (kernel == null)
			{
				throw new ArgumentNullException("kernel");
			}

			this.kernel = kernel;
		}

		public void Dispatch<TCommand, TEntity>(TCommand command) 
			where TCommand : ICommand
			where TEntity : IEntity
		{
			var handler = this.kernel.Get<ICommandHandler<TCommand, TEntity>>();

			var config = this.kernel.Get<IConfiguration>();
			IReadRepository<TEntity> read = this.kernel.Get<IReadRepository<TEntity>>();
			read.Initialize(config);
			IWriteRepository<TEntity> write = this.kernel.Get<IWriteRepository<TEntity>>();
			write.Initialize(config);
			handler.ReadRepository = read;
			handler.WriteRepository = write;

			handler.Execute(command);
		}
	}
}
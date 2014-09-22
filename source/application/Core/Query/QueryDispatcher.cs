namespace Archer.Core.Query
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;
	using Archer.Core.Repository;
	using Ninject;

	public class QueryDispatcher : IQueryDispatcher
	{
		private readonly IKernel kernel;

		public QueryDispatcher(IKernel kernel)
		{
			if (kernel == null)
			{
				throw new ArgumentNullException("kernel");
			}
			this.kernel = kernel;
		}

		public TResult Dispatch<TParameter, TResult, TEntity>(TParameter query)
			where TParameter : IQuery
			where TResult : IQueryResult
			where TEntity : IEntity
		{
			var handler = this.kernel.Get<IQueryHandler<TParameter, TResult, TEntity>>();
			
			var config = this.kernel.Get<IConfiguration>();
			IReadRepository<TEntity> read = this.kernel.Get<IReadRepository<TEntity>>();
			read.Initialize(config);
			IWriteRepository<TEntity> write = this.kernel.Get<IWriteRepository<TEntity>>();
			write.Initialize(config);
			handler.ReadRepository = read;
			handler.WriteRepository = write;

			return handler.Retrieve(query);
		}
	}
}
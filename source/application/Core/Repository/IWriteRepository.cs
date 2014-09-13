namespace Archer.Core.Repository
{
	using System;
	using Archer.Core.Configuration;
	using Archer.Core.Entity;

	public interface IWriteRepository<TEntity> where TEntity : IEntity
	{
		IConfiguration Config { get; set; }

		bool Delete(TEntity entity);

		void Initialize(IConfiguration config);

		bool Insert(TEntity entity);

		bool Update(TEntity entity);
	}
}
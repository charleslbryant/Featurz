namespace Archer.Core.Entity
{
	using System;

	public class EntityBase : IEntity
	{
		public EntityBase(string id)
		{
			this.Id = id;
		}

		public string Id { get; protected set; }
	}
}
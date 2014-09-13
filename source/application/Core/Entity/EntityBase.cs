namespace Archer.Core.Entity
{
	using System;

	public class EntityBase : IEntity
	{
		public EntityBase(string id)
		{
			this.Id = id;
			this.DateAdded = DateTime.Now;
		}

		public string Id { get; protected set; }

		public DateTime DateAdded { get; protected set; }
	}
}
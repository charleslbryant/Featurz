namespace Archer.Core.Entity
{
	using System;

	public class NamedEntity : EntityBase
	{
		public NamedEntity(string id, string name)
			: base(id)
		{
			this.Name = name;
		}
		public string Name { get; protected set; }
	}
}

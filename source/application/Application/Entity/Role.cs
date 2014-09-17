namespace Featurz.Application.Entity
{
	using System;
	using Archer.Core.Entity;

	public class Role : NamedEntity
	{
		public Role(string id, string name)
			: base(id, name)
		{
		}
	}
}
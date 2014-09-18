namespace Featurz.Application.Entity
{
	using System;
	using Archer.Core.Entity;

	public class Group : NamedEntity
	{
		public Group(string id, string name)
			: base(id, name)
		{
		}
	}
}
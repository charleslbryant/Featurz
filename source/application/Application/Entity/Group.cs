namespace Featurz.Application.Entity
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;

	public class Group : NamedEntity
	{
		public Group(string id, string name, ICollection<Role> roles)
			: base(id, name)
		{
			this.Roles = roles;
		}

		public ICollection<Role> Roles { get; private set; }
	}
}
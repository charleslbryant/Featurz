namespace Featurz.Application.Entity
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;

	public class FeatureUser : EntityBase
	{
		public FeatureUser(string id, ICollection<string> roles)
			: base(id)
		{
			this.Roles = roles;
		}

		public ICollection<string> Roles { get; set; }
	}
}

namespace Featurz.Application.Entity
{
	using System;
	using Archer.Core.Entity;

	public class FeatureContext : EntityBase
	{
		public FeatureContext(string id, User user)
			: base(id)
		{
			this.User = user;
		}

		public User User { get; private set; }
	}
}
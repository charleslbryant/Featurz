namespace Featurz.Application.Entity
{
	using System;
	using Archer.Core.Entity;

	public class FeatureContext : EntityBase
	{
		public FeatureContext(string id, FeatureUser user)
			: base(id)
		{
			this.User = user;
		}

		public FeatureUser User { get; private set; }
	}
}
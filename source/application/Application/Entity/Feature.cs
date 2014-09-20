namespace Featurz.Application.Entity
{
	using System;
	using Archer.Core.Entity;

	public class Feature : NamedEntity
	{
		public Feature(string id, DateTime dateAdded, string name, string userId, string ticket = "", bool isActive = false, bool isEnabled = false, int strategyId = 0)
			: base(id, name)
		{
			this.IsActive = isActive;
			this.IsEnabled = isEnabled;
			this.StrategyId = strategyId;
			this.Ticket = ticket;
			this.UserId = userId;
			this.DateAdded = dateAdded;
		}

		public DateTime DateAdded { get; protected set; }

		public bool IsActive { get; private set; }

		public bool IsEnabled { get; private set; }

		public int StrategyId { get; private set; }

		public string Ticket { get; private set; }

		public string UserId { get; private set; }
	}
}
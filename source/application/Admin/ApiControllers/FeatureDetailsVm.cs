namespace Featurz.Admin.ApiControllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;


	public class FeatureDetailsVm
	{
		public FeatureDetailsVm(string id, string name, string userId, string ticket = "", bool isActive = false, bool isEnabled = false, int strategyId = 0)
		{
			this.Id = id;
			this.Name = name;
			this.IsActive = isActive;
			this.IsEnabled = isEnabled;
			this.StrategyId = strategyId;
			this.Ticket = ticket;
			this.UserId = userId;
		}

		public string Id { get; set; }

		public bool IsActive { get; set; }

		public bool IsEnabled { get; set; }

		public string Name { get; set; }

		public int StrategyId { get; set; }

		public string Ticket { get; set; }

		public string UserId { get; set; }
	}
}

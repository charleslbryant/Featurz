namespace Featurz.Application.QueryResult
{
	using System;
	using Archer.Core.Query;

	public class GetFeatureByIdQueryResult : IQueryResult
	{
		public GetFeatureByIdQueryResult(string id, string name, string userId, string ticket = "", bool isActive = false, bool isEnabled = false, int strategyId = 0)
		{
			this.Id = id;
			this.Name = name;
			this.IsActive = isActive;
			this.IsEnabled = isEnabled;
			this.StrategyId = strategyId;
			this.Ticket = Ticket;
			this.UserId = userId;
		}

		public string Id { get; private set; }

		public bool IsActive { get; private set; }

		public bool IsEnabled { get; private set; }

		public string Name { get; private set; }

		public int StrategyId { get; private set; }

		public string Ticket { get; private set; }

		public string UserId { get; private set; }
	}
}
namespace Featurz.Web.ViewModel.Feature
{
	using System;

	public class FeatureListItemVm
	{
		public string Active { get; set; }

		public string ActiveClass { get; set; }

		public DateTime DateAdded { get; set; }

		public string Enabled { get; set; }

		public string EnabledClass { get; set; }

		public string Id { get; set; }

		public string Name { get; set; }

		public string Owner { get; set; }

		public int StrategyId { get; set; }

		public string Ticket { get; set; }

		public string TicketLink { get; set; }
	}
}
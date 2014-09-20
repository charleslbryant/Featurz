namespace Featurz.Web.ViewModel.Feature
{
	using System;

	public class FeatureEditVm : BaseVm
	{
		public DateTime DateAdded { get; set; }

		public string Id { get; set; }

		public bool IsActive { get; set; }

		public bool IsEnabled { get; set; }

		public string Name { get; set; }

		public string NameError { get; set; }

		public string NameGroupError { get; set; }

		public string NameMessage { get; set; }

		public int StrategyId { get; set; }

		public string Ticket { get; set; }

		public string TicketError { get; set; }

		public string TicketGroupError { get; set; }

		public string TicketMessage { get; set; }

		public string UserId { get; set; }
	}
}
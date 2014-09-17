namespace Featurz.Web.ViewModel.Feature
{
	using System;

	public class FeatureEditVm : BaseVm
	{
		public string Id { get; set; }

		public bool IsActive { get; set; }

		public bool IsEnabled { get; set; }

		public string Name { get; set; }

		public string NameError { get; set; }

		public string NameGroupError { get; set; }

		public string NameMessage { get; set; }

		public int StrategyId { get; set; }

		public string Ticket { get; set; }

		public object TicketError { get; set; }

		public object TicketGroupError { get; set; }

		public object TicketMessage { get; set; }

		public string UserId { get; set; }
	}
}
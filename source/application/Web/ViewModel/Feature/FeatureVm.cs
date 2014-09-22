namespace Featurz.Web.ViewModel.Feature
{
	using System;

	public class FeatureVm : BaseVm
	{
		public FeatureVm()
		{
			this.TicketMessage = new ViewMessageVm();

			this.NameMessage = new ViewMessageVm();

			this.IdMessage = new ViewMessageVm();
		}

		public DateTime DateAdded { get; set; }

		public string Id { get; set; }

		public bool IsActive { get; set; }

		public bool IsEnabled { get; set; }

		public string Name { get; set; }

		public int StrategyId { get; set; }

		public string Ticket { get; set; }

		public string UserId { get; set; }

		public ViewMessageVm TicketMessage { get; set; }

		public ViewMessageVm NameMessage { get; set; }

		public ViewMessageVm IdMessage { get; set; }
	}
}
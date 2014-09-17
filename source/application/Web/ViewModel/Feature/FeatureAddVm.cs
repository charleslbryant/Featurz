namespace Featurz.Web.ViewModel.Feature
{
	using System;

	public class FeatureAddVm : BaseVm
	{
		public string NameError { get; set; }

		public string NameGroupError { get; set; }

		public string NameMessage { get; set; }

		public object TicketError { get; set; }

		public object TicketGroupError { get; set; }

		public object TicketMessage { get; set; }
	}
}
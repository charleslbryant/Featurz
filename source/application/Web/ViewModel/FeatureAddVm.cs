namespace Featurz.Web.ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class FeatureAddVm : BaseVm
	{
		public string NameMessage { get; set; }

		public string NameError { get; set; }

		public string NameGroupError { get; set; }

		public object TicketGroupError { get; set; }

		public object TicketError { get; set; }

		public object TicketMessage { get; set; }
	}
}

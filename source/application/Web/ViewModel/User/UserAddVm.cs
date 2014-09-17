namespace Featurz.Web.ViewModel
{
	using System;

	public class UserAddVm : BaseVm
	{
		public ViewMessageVm EmailMessage { get; set; }

		public ViewMessageVm FirstNameMessage { get; set; }

		public ViewMessageVm LastNameMessage { get; set; }
	}
}
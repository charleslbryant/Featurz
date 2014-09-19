namespace Featurz.Web.ViewModel.User
{
	using System;

	public class UserAddVm : BaseVm
	{
		public UserAddVm()
		{
			this.EmailMessage = new ViewMessageVm();
			this.FirstNameMessage = new ViewMessageVm();
			this.LastNameMessage = new ViewMessageVm();
		}

		public ViewMessageVm EmailMessage { get; set; }

		public ViewMessageVm FirstNameMessage { get; set; }

		public ViewMessageVm LastNameMessage { get; set; }
	}
}
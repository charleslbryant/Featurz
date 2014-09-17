namespace Featurz.Web.ViewModel
{
	using System;
	using System.Collections.Generic;

	public class UserEditVm : BaseVm
	{
		public string Email { get; private set; }

		public ViewMessageVm EmailMessage { get; set; }

		public string FirstName { get; private set; }

		public ViewMessageVm FirstNameMessage { get; set; }

		public ICollection<string> Groups { get; private set; }

		public string Id { get; private set; }

		public string InvalidEmail { get; set; }

		public string InvalidLastName { get; set; }

		public string InvalidLastName { get; set; }

		public bool IsEnabled { get; private set; }

		public string LastName { get; private set; }

		public ViewMessageVm LastNameMessage { get; set; }

		public string Message { get; set; }

		public ICollection<string> Roles { get; private set; }

		public bool Valid { get; set; }
	}
}
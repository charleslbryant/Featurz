namespace Featurz.Web.ViewModel.User
{
	using System;
	using System.Collections.Generic;

	public class UserVm : BaseVm
	{
		public DateTime DateAdded { get; set; }

		public string Email { get; set; }

		public ViewMessageVm EmailMessage { get; set; }

		public string FirstName { get; set; }

		public ViewMessageVm FirstNameMessage { get; set; }

		public ICollection<string> Groups { get; set; }

		public string Id { get; set; }

		public bool IsEnabled { get; set; }

		public string LastName { get; set; }

		public ViewMessageVm LastNameMessage { get; set; }

		public ICollection<string> Roles { get; set; }

		public string Username { get; set; }

		public ViewMessageVm UsernameMessage { get; set; }
	}
}
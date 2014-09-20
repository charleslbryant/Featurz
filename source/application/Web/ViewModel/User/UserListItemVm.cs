namespace Featurz.Web.ViewModel.User
{
	using System;
	using System.Collections.Generic;

	public class UserListItemVm
	{
		public string DateAdded { get; set; }

		public string Email { get; set; }

		public string Enabled { get; set; }

		public string EnabledClass { get; set; }

		public string FirstName { get; set; }

		public ICollection<string> Groups { get; set; }

		public string Id { get; set; }

		public string LastName { get; set; }

		public string Name
		{
			get
			{
				return this.FirstName + " " + this.LastName;
			}
		}

		public ICollection<string> Roles { get; set; }
	}
}
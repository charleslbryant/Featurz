namespace Featurz.Application.Command
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;

	public class EditUserCommand : ICommand
	{
		public EditUserCommand(string id, string firstName, string lastName, string email, ICollection<string> roles, ICollection<string> groups, bool isEnabled)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
			this.Roles = roles;
			this.Groups = groups;
			this.IsEnabled = isEnabled;
			this.Valid = true;
		}

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public ICollection<string> Groups { get; private set; }

		public string Id { get; private set; }

		public string InvalidEmail { get; set; }

		public string InvalidLastName { get; set; }

		public string InvalidLastName { get; set; }

		public bool IsEnabled { get; private set; }

		public string LastName { get; private set; }

		public string Message { get; set; }

		public ICollection<string> Roles { get; private set; }

		public bool Valid { get; set; }
	}
}
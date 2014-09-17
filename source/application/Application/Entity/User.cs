namespace Featurz.Application.Entity
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;

	public class User : EntityBase
	{
		public User(string id, string email, string firstName, string lastName, ICollection<string> roles, ICollection<string> groups, bool isEnabled)
			: base(id)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Roles = roles;
			this.Groups = groups;
			this.IsEnabled = isEnabled;
		}

		public string Email { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public ICollection<string> Roles { get; set; }

		public ICollection<string> Groups { get; set; }

		public bool IsEnabled { get; set; }
	}
}
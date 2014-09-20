namespace Featurz.Application.Entity
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;

	public class User : EntityBase
	{
		public User(string id, DateTime dateAdded, string email, string firstName, string lastName, ICollection<string> roles, ICollection<string> groups, bool isEnabled)
			: base(id)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Roles = roles;
			this.Groups = groups;
			this.IsEnabled = isEnabled;
			this.DateAdded = dateAdded;
		}

		public DateTime DateAdded { get; private set; }

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public ICollection<string> Groups { get; private set; }

		public bool IsEnabled { get; private set; }

		public string LastName { get; private set; }

		public ICollection<string> Roles { get; private set; }
	}
}
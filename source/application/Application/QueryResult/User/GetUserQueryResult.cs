namespace Featurz.Application.QueryResult.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Query;

	public class GetUserQueryResult : IQueryResult
	{
		public GetUserQueryResult(string id, string firstName, string lastName, string email, ICollection<string> roles, ICollection<string> groups, bool isEnabled)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
			this.Roles = roles;
			this.Groups = groups;
			this.IsEnabled = isEnabled;
		}

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public ICollection<string> Groups { get; private set; }

		public string Id { get; private set; }

		public bool IsEnabled { get; private set; }

		public string LastName { get; private set; }

		public ICollection<string> Roles { get; private set; }
}
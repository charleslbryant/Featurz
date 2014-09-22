namespace Featurz.Application.Command.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;

	public class AddUserCommand : UserCommand
	{
		public AddUserCommand(string id, DateTime dateAdded, string firstName, string lastName, string email, ICollection<string> roles, ICollection<string> groups, bool isEnabled)
			: base(id, dateAdded, firstName, lastName, email, roles, groups, isEnabled)
		{
		}
	}
}
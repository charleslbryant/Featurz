namespace Featurz.Application.Tests.Unit.CommandHandler.User
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Featurz.Application.Command.User;

	public class UserCommandHandlerTestHelper
	{
		public static UserCommand GetCommand(string id = null, string firstName = null, string lastName = null, string email = null)
		{
			string defaultId = "id1";
			string defaultFirstName = "User 1";
			string defaultLastName = "User 1";
			string defaultEmail = "tester@abc.comx";
			DateTime date = DateTime.Now;
			ICollection<string> roles = null;
			ICollection<string> groups = null;
			bool isEnabled = true;

			id = id ?? defaultId;
			firstName = firstName ?? defaultFirstName;
			lastName = lastName ?? defaultLastName;
			email = email ?? defaultEmail;

			UserCommand command = new UserCommand(id, date, firstName, lastName, email, roles, groups, isEnabled);
			return command;
		}

		public static AddUserCommand GetAddCommand(string id = null, string firstName = null, string lastName = null, string email = null)
		{
			string defaultId = "id1";
			string defaultFirstName = "User 1";
			string defaultLastName = "User 1";
			string defaultEmail = "tester@abc.comx";
			DateTime date = DateTime.Now;
			ICollection<string> roles = null;
			ICollection<string> groups = null;
			bool isEnabled = true;

			id = id ?? defaultId;
			firstName = firstName ?? defaultFirstName;
			lastName = lastName ?? defaultLastName;
			email = email ?? defaultEmail;

			AddUserCommand command = new AddUserCommand(id, date, firstName, lastName, email, roles, groups, isEnabled);
			return command;
		}

		public static EditUserCommand GetEditCommand(string id = null, string firstName = null, string lastName = null, string email = null)
		{
			string defaultId = "id1";
			string defaultFirstName = "User 1";
			string defaultLastName = "User 1";
			string defaultEmail = "tester@abc.comx";
			DateTime date = DateTime.Now;
			ICollection<string> roles = null;
			ICollection<string> groups = null;
			bool isEnabled = true;

			id = id ?? defaultId;
			firstName = firstName ?? defaultFirstName;
			lastName = lastName ?? defaultLastName;
			email = email ?? defaultEmail;

			EditUserCommand command = new EditUserCommand(id, date, firstName, lastName, email, roles, groups, isEnabled);
			return command;
		}
	}
}

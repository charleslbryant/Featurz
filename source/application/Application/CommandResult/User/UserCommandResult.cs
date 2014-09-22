namespace Featurz.Application.CommandResult.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;

	public class UserCommandResult : CommandResultBase
	{
		public UserCommandResult()
		{
		}

		public string InvalidId { get; set; }

		public string InvalidEmail { get; set; }

		public string InvalidFirstName { get; set; }

		public string InvalidLastName { get; set; }
	}
}
namespace Featurz.Application.CommandHandler.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;
	using Featurz.Application.Command.User;
	using Featurz.Application.CommandResult.User;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;

	public class AddUserCommandHandler : BaseCommandHandler<User>, ICommandHandler<AddUserCommand, UserCommandResult, User>
	{
		public AddUserCommandHandler()
		{
		}

		public UserCommandResult Execute(AddUserCommand command)
		{
			UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.WriteRepository, this.ReadRepository);

			if (!result.Valid)
			{
				return result;
			}

			User user = new User(command.Id, command.DateAdded, command.Email, command.FirstName, command.LastName, command.Roles, command.Groups, command.IsEnabled);

			this.WriteRepository.Insert(user);

			return result;
		}
	}
}
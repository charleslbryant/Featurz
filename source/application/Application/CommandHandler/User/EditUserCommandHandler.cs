namespace Featurz.Application.CommandHandler.User
{
	using System;
	using Archer.Core.Command;
	using Featurz.Application.Command.User;
	using Featurz.Application.CommandResult.User;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;

	public class EditUserCommandHandler : BaseCommandHandler<User>, ICommandHandler<EditUserCommand, UserCommandResult, User>
	{
		public EditUserCommandHandler()
		{
		}

		public UserCommandResult Execute(EditUserCommand command)
		{
			UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.WriteRepository, this.ReadRepository);

			if (!result.Valid)
			{
				return result;
			}

			User user = new User(command.Id, command.DateAdded, command.FirstName, command.LastName, command.Email, command.Roles, command.Groups, command.IsEnabled);

			this.WriteRepository.Update(user);

			return result;
		}
	}
}
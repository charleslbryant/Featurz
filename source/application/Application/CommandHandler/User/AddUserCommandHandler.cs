namespace Featurz.Application.CommandHandler.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;
	using Featurz.Application.Command.User;
	using Featurz.Application.Entity;
	using Featurz.Application.Exceptions;

	public class AddUserCommandHandler : BaseCommandHandler<User>, ICommandHandler<AddUserCommand, User>
	{
		public AddUserCommandHandler()
		{
		}

		public void Execute(AddUserCommand command)
		{
			this.Validate(command);

			User user = new User(command.Id, command.DateAdded, command.Email, command.FirstName, command.LastName, command.Roles, command.Groups, command.IsEnabled);

			this.WriteRepository.Insert(user);
		}

		private IList<User> GetUserByEmail(string email)
		{
			IList<User> features = this.ReadRepository.Where(x => x.Email == email);
			return features;
		}

		private bool IsDuplicateUserEmail(string email)
		{
			return this.GetUserByEmail(email).Count > 0;
		}

		private void Validate(AddUserCommand command)
		{
			// TODO: Research how to handle concurrency in MongoDb.
			// I am still a MongoDb newbie so there is probably a better way to handle concurrency issues.
			// For now, if a duplicate feature is found we will throw an exception.
			if (IsDuplicateUserEmail(command.Email))
			{
				throw new DuplicateItemException(string.Format("A user already exists with the email {0}", command.Email));
			}

			if (this.WriteRepository == null)
			{
				throw new Exception("WriteRespository can not be a null value;");
			}

			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			if (string.IsNullOrWhiteSpace(command.Id))
			{
				throw new ArgumentException("command.Id cannot be null or white space.");
			}
		}
	}
}
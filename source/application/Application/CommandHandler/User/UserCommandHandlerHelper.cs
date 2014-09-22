namespace Featurz.Application.CommandHandler.User
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Archer.Core.Repository;
	using Featurz.Application.Command.User;
	using Featurz.Application.CommandResult.User;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;

	public class UserCommandHandlerHelper
	{
		private static bool IsDuplicateEmail(string email, IReadRepository<User> read)
		{
			IList<User> users = read.Where(x => x.Email == email);
			return users.Count > 0;
		}

		private static bool IsDuplicateId(string id, IReadRepository<User> read)
		{
			return read.GetById(id) != null;
		}

		public static UserCommandResult Validate(UserCommand command, IWriteRepository<User> write, IReadRepository<User> read)
		{
			if (write == null)
			{
				throw new Exception("WriteRespository can not be a null value;");
			}

			if (read == null)
			{
				throw new Exception("ReadRespository can not be a null value;");
			}

			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			UserCommandResult result = new UserCommandResult();

			// TODO: Research how to handle concurrency in MongoDb.
			// I am still a MongoDb newbie so there is probably a better way to handle concurrency issues.
			// For now, if a duplicate is found we will throw an exception.
			if (UserCommandHandlerHelper.IsDuplicateId(command.Id, read))
			{
				result.Valid = false;
				result.InvalidId = string.Format("A user already exists with the username {0}", command.Id);
			}

			if (string.IsNullOrWhiteSpace(command.Id))
			{
				result.Valid = false;
				result.InvalidId = MessagesModel.Required;
			}

			if (command.Id != null && command.Id.Length > 50)
			{
				result.Valid = false;
				result.InvalidId = string.Format(MessagesModel.MaxLength, "50");
			}

			if (string.IsNullOrWhiteSpace(command.FirstName))
			{
				result.Valid = false;
				result.InvalidFirstName = MessagesModel.Required;
			}

			if (command.FirstName != null && command.FirstName.Length > 100)
			{
				result.Valid = false;
				result.InvalidFirstName = string.Format(MessagesModel.MaxLength, "100");
			}

			if (string.IsNullOrWhiteSpace(command.LastName))
			{
				result.Valid = false;
				result.InvalidLastName = MessagesModel.Required;
			}

			if (command.LastName != null && command.LastName.Length > 100)
			{
				result.Valid = false;
				result.InvalidLastName = string.Format(MessagesModel.MaxLength, "100");
			}

			if (IsDuplicateEmail(command.Email, read))
			{
				result.Valid = false;
				result.InvalidEmail = string.Format("A user already exists with the email {0}", command.Email);
			}

			if (string.IsNullOrWhiteSpace(command.Email))
			{
				result.Valid = false;
				result.InvalidEmail = MessagesModel.Required;
			}

			if (command.Email != null && command.Email.Length > 255)
			{
				result.Valid = false;
				result.InvalidEmail = string.Format(MessagesModel.MaxLength, "255");
			}

			if (!Validator.IsEmail(command.Email))
			{
				result.Valid = false;
				result.InvalidEmail = MessagesModel.InvalidEmail;
			}

			return result;
		}
	}
}

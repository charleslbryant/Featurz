namespace Featurz.Web.Model
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Exceptions;
	using Archer.Core.Query;
	using Featurz.Application.Command.User;
	using Featurz.Application.Entity;
	using Featurz.Application.Exceptions;
	using Featurz.Application.Query.User;
	using Featurz.Application.QueryResult.User;
	using Featurz.Web.ViewModel.User;

	public class UserModel
	{
		private readonly ICommandDispatcher commandDispatcher;
		private readonly IConfiguration config;
		private readonly IQueryDispatcher queryDispatcher;

		public UserModel(IConfiguration config, IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
		{
			this.config = config;
			this.queryDispatcher = queryDispatcher;
			this.commandDispatcher = commandDispatcher;
		}

		public AddUserCommand AddUser(AddUserCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "command"));
			}

			this.ValidateAddUserCommand(command);

			if (!command.Valid)
			{
				return command;
			}

			try
			{
				this.commandDispatcher.Dispatch<AddUserCommand, User>(command);
			}
			catch (DuplicateItemException)
			{
				command.Valid = false;
				command.InvalidEmail = string.Format(MessagesModel.DuplicateUseException, "email", command.Email, "email");
			}
			catch (DuplicateKeyException)
			{
				command.Valid = false;
				command.Message = string.Format(MessagesModel.DuplicateKeyException, command.Id);
			}
			return command;
		}

		//TODO: Decide what happens if we happen to have a duplicate key here.
		//public EditUserCommand EditUser(EditUserCommand command)
		//{
		//	if (command == null)
		//	{
		//		throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "command"));
		//	}

		//	this.ValidateEditUserCommand(command);

		//	if (!command.Valid)
		//	{
		//		return command;
		//	}

		//	try
		//	{
		//		this.commandDispatcher.Dispatch<EditUserCommand, User>(command);
		//	}
		//	catch (DuplicateItemException)
		//	{
		//		command.Valid = false;
		//		command.InvalidEmail = string.Format(MessagesModel.DuplicateUseException, "email", command.Email, "email");
		//	}
		//	catch (DuplicateKeyException)
		//	{
		//		command.Valid = false;
		//		command.Message = string.Format(MessagesModel.DuplicateKeyException, command.Id);
		//	}
		//	return command;
		//}

		//public UserEditVm GetUserById(GetUserByIdQuery query)
		//{
		//	if (query == null)
		//	{
		//		throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "query"));
		//	}

		//	GetUserQueryResult result = this.queryDispatcher.Dispatch<GetUserByIdQuery, GetUserQueryResult, User>(query);

		//	UserEditVm vm = UserModelHelper.ToUserEditVm(result);

		//	return vm;
		//}
		public ICollection<UserGroupVm> GetUserGroups(GetUserGroupsQuery query)
		{
			if (query == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "query"));
			}

			ICollection<UserGroupVm> groups = new List<UserGroupVm>();
			GetUserGroupsQueryResult results = this.queryDispatcher.Dispatch<GetUserGroupsQuery, GetUserGroupsQueryResult, User>(query);

			foreach (var group in results.UserGroups)
			{
				UserGroupVm userGroup = UserModelHelper.ToUserGroupVm(group);
				groups.Add(userGroup);
			}

			return groups;
		}

		public ICollection<UserRoleVm> GetUserRoles(GetUserRolesQuery query)
		{
			if (query == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "query"));
			}

			ICollection<UserRoleVm> roles = new List<UserRoleVm>();
			GetUserRolesQueryResult results = this.queryDispatcher.Dispatch<GetUserRolesQuery, GetUserRolesQueryResult, User>(query);

			foreach (var role in results.UserRoles)
			{
				UserRoleVm userRole = UserModelHelper.ToUserRoleVm(role);
				roles.Add(userRole);
			}

			return roles;
		}

		public UserListVm GetUsers(GetUsersQuery query)
		{
			if (query == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "query"));
			}

			GetUsersQueryResult results = this.queryDispatcher.Dispatch<GetUsersQuery, GetUsersQueryResult, User>(query);

			UserListVm vm = UserModelHelper.ToUserListVm(results, config);

			return vm;
		}

		public UserAddVm SetUserAddVm(AddUserCommand command, UserAddVm vm)
		{
			if (command == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "command"));
			}

			if (vm == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "vm"));
			}

			if (command.Valid)
			{
				return vm;
			}

			vm.Message = MessagesModel.FormError;

			if (!string.IsNullOrWhiteSpace(command.Message))
			{
				vm.Message = command.Message;
			}

			vm.MessageStyle = MessagesModel.MessageStyles.Error;

			if (!string.IsNullOrWhiteSpace(command.InvalidFirstName))
			{
				vm.FirstNameMessage.Message = MessagesModel.ItemMessage + command.InvalidFirstName;
				vm.FirstNameMessage.Error = MessagesModel.ItemError;
				vm.FirstNameMessage.GroupError = MessagesModel.ItemGroupError;
			}

			if (!string.IsNullOrWhiteSpace(command.InvalidLastName))
			{
				vm.LastNameMessage.Message = MessagesModel.ItemMessage + command.InvalidLastName;
				vm.LastNameMessage.Error = MessagesModel.ItemError;
				vm.LastNameMessage.GroupError = MessagesModel.ItemGroupError;
			}

			if (!string.IsNullOrWhiteSpace(command.InvalidEmail))
			{
				vm.EmailMessage.Message = MessagesModel.ItemMessage + command.InvalidEmail;
				vm.EmailMessage.Error = MessagesModel.ItemError;
				vm.EmailMessage.GroupError = MessagesModel.ItemGroupError;
			}

			return vm;
		}

		//public UserEditVm SetUserEditVm(EditUserCommand command, UserEditVm vm)
		//{
		//	if (command == null)
		//	{
		//		throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "command"));
		//	}

		//	if (vm == null)
		//	{
		//		throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "vm"));
		//	}

		//	if (command.Valid)
		//	{
		//		return vm;
		//	}

		//	vm.Message = MessagesModel.FormError;

		//	if (!string.IsNullOrWhiteSpace(command.Message))
		//	{
		//		vm.Message = command.Message;
		//	}

		//	vm.MessageStyle = MessagesModel.MessageStyles.Error;

		//	if (!string.IsNullOrWhiteSpace(command.InvalidName))
		//	{
		//		vm.NameMessage = MessagesModel.ItemMessage + command.InvalidName;
		//		vm.NameError = MessagesModel.ItemError;
		//		vm.NameGroupError = MessagesModel.ItemGroupError;
		//	}

		//	if (!string.IsNullOrWhiteSpace(command.InvalidTicket))
		//	{
		//		vm.TicketMessage = MessagesModel.ItemMessage + command.InvalidTicket;
		//		vm.TicketError = MessagesModel.ItemError;
		//		vm.TicketGroupError = MessagesModel.ItemGroupError;
		//	}

		//	return vm;
		//}
		private AddUserCommand ValidateAddUserCommand(AddUserCommand command)
		{
			if (string.IsNullOrWhiteSpace(command.FirstName))
			{
				command.Valid = false;
				command.InvalidFirstName = MessagesModel.Required;
			}

			if (command.FirstName != null && command.FirstName.Length > 100)
			{
				command.Valid = false;
				command.InvalidFirstName = string.Format(MessagesModel.MaxLength, "100");
			}

			if (string.IsNullOrWhiteSpace(command.LastName))
			{
				command.Valid = false;
				command.InvalidLastName = MessagesModel.Required;
			}

			if (command.LastName != null && command.LastName.Length > 100)
			{
				command.Valid = false;
				command.InvalidLastName = string.Format(MessagesModel.MaxLength, "100");
			}

			if (string.IsNullOrWhiteSpace(command.Email))
			{
				command.Valid = false;
				command.InvalidEmail = MessagesModel.Required;
			}

			if (command.Email != null && command.Email.Length > 255)
			{
				command.Valid = false;
				command.InvalidLastName = string.Format(MessagesModel.MaxLength, "50");
			}

			if (!Validator.IsEmail(command.Email))
			{
				command.Valid = false;
				command.InvalidLastName = MessagesModel.InvalidEmail;
			}

			return command;
		}

		//private EditUserCommand ValidateEditUserCommand(EditUserCommand command)
		//{
		//	if (string.IsNullOrWhiteSpace(command.Name))
		//	{
		//		command.Valid = false;
		//		command.InvalidName = MessagesModel.Required;
		//	}

		//	if (command.Name != null && command.Name.Length > 100)
		//	{
		//		command.Valid = false;
		//		command.InvalidName = string.Format(MessagesModel.MaxLength, "100");
		//	}

		//	if (command.Ticket != null && command.Ticket.Length > 50)
		//	{
		//		command.Valid = false;
		//		command.InvalidTicket = string.Format(MessagesModel.MaxLength, "50");
		//	}

		//	return command;
		//}
	}
}
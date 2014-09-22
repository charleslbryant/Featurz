namespace Featurz.Web.Model
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Query;
	using Featurz.Application.Command.User;
	using Featurz.Application.CommandResult.User;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;
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

		public UserVm AddUser(UserVm vm)
		{
			if (vm == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "UserVm view"));
			}

			AddUserCommand command = new AddUserCommand(vm.Id, vm.DateAdded, vm.FirstName, vm.LastName, vm.Email, vm.Roles, vm.Groups, vm.IsEnabled);

			UserCommandResult result = this.commandDispatcher.Dispatch<AddUserCommand, UserCommandResult, User>(command);

			vm = UserModelHelper.CommandResultToUserVm(result);

			return vm;
		}

		//TODO: Decide what happens if we happen to have a duplicate key here.
		public UserVm EditUser(UserVm vm)
		{
			if (vm == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "UserEditVm view"));
			}

			EditUserCommand command = new EditUserCommand(vm.Id, vm.DateAdded, vm.FirstName, vm.LastName, vm.Email, vm.Roles, vm.Groups, vm.IsEnabled);

			UserCommandResult result = this.commandDispatcher.Dispatch<EditUserCommand, UserCommandResult, User>(command);

			vm = UserModelHelper.CommandResultToUserVm(result);

			return vm;
		}

		public UserVm GetUserById(UserVm vm)
		{
			if (vm == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "UserEditVm vm"));
			}

			GetUserByIdQuery query = new GetUserByIdQuery(vm.Id);

			GetUserQueryResult result = this.queryDispatcher.Dispatch<GetUserByIdQuery, GetUserQueryResult, User>(query);

			vm = UserModelHelper.QueryResultToUserVm(result);

			return vm;
		}

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
				UserGroupVm userGroup = UserModelHelper.ResultToUserGroupVm(group);
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
				UserRoleVm userRole = UserModelHelper.ResultToUserRoleVm(role);
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

			UserListVm vm = UserModelHelper.ResultToUserListVm(results, this.config);

			return vm;
		}
	}
}
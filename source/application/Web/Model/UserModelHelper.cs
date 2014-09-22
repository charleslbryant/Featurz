namespace Featurz.Web.Model
{
	using System;
	using Archer.Core.Configuration;
	using Featurz.Application.CommandResult.User;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;
	using Featurz.Application.QueryResult.User;
	using Featurz.Web.ViewModel.User;

	public class UserModelHelper
	{
		public static UserVm CommandResultToUserVm(UserCommandResult result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "UserCommandResult result"));
			}

			UserVm vm = new UserVm();

			vm.Message = MessagesModel.FormError;

			if (!string.IsNullOrWhiteSpace(result.Message))
			{
				vm.Message = result.Message;
			}

			vm.MessageStyle = MessagesModel.MessageStyles.Error;

			if (!string.IsNullOrWhiteSpace(result.InvalidFirstName))
			{
				vm.FirstNameMessage.Message = MessagesModel.ItemMessage + result.InvalidFirstName;
				vm.FirstNameMessage.Error = MessagesModel.ItemError;
				vm.FirstNameMessage.GroupError = MessagesModel.ItemGroupError;
			}

			if (!string.IsNullOrWhiteSpace(result.InvalidLastName))
			{
				vm.LastNameMessage.Message = MessagesModel.ItemMessage + result.InvalidLastName;
				vm.LastNameMessage.Error = MessagesModel.ItemError;
				vm.LastNameMessage.GroupError = MessagesModel.ItemGroupError;
			}

			if (!string.IsNullOrWhiteSpace(result.InvalidEmail))
			{
				vm.EmailMessage.Message = MessagesModel.ItemMessage + result.InvalidEmail;
				vm.EmailMessage.Error = MessagesModel.ItemError;
				vm.EmailMessage.GroupError = MessagesModel.ItemGroupError;
			}

			return vm;
		}

		public static UserVm QueryResultToUserVm(GetUserQueryResult result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			UserVm vm = new UserVm();

			vm.DateAdded = result.DateAdded;
			vm.Id = result.Id;
			vm.FirstName = result.FirstName;
			vm.LastName = result.LastName;
			vm.Email = result.Email;
			vm.Roles = result.Roles;
			vm.Groups = result.Groups;
			vm.IsEnabled = result.IsEnabled;

			return vm;
		}

		public static UserGroupVm ResultToUserGroupVm(Group result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			UserGroupVm vm = new UserGroupVm();
			vm.Id = result.Id;
			vm.Name = result.Name;
			return vm;
		}

		public static UserListVm ResultToUserListVm(GetUsersQueryResult results, IConfiguration config)
		{
			if (results == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "results"));
			}

			if (config == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "config"));
			}

			UserListVm vm = new UserListVm();
			vm.ItemsFound = results.Users.Count > 0;

			if (!vm.ItemsFound)
			{
				vm.Message = MessagesModel.NoItemsFound;
				vm.MessageStyle = MessagesModel.MessageStyles.Info;
			}

			foreach (var result in results.Users)
			{
				UserListItemVm user = ResultToUserLitsItemVm(result, config);
				vm.Users.Add(user);
			}

			return vm;
		}

		public static UserRoleVm ResultToUserRoleVm(Role result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			UserRoleVm vm = new UserRoleVm();
			vm.Id = result.Id;
			vm.Name = result.Name;
			return vm;
		}

		public static UserListItemVm SetEnabled(UserListItemVm user, User result)
		{
			if (user == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "feature"));
			}

			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			if (result.IsEnabled)
			{
				user.Enabled = "Enabled";
				user.EnabledClass = "success";
				return user;
			}

			user.Enabled = "Disabled";
			user.EnabledClass = "danger";
			return user;
		}

		private static UserListItemVm ResultToUserLitsItemVm(User result, IConfiguration config)
		{
			UserListItemVm user = new UserListItemVm();
			user.DateAdded = result.DateAdded.ToShortDateString();
			user.Id = result.Id;
			user.FirstName = result.FirstName;
			user.LastName = result.LastName;
			user.Email = result.Email;
			user.Roles = result.Roles;
			user.Groups = result.Groups;
			user = UserModelHelper.SetEnabled(user, result);
			return user;
		}
	}
}
namespace Featurz.Web.Model
{
	using System;
	using Archer.Core.Configuration;
	using Featurz.Application.Entity;
	using Featurz.Application.QueryResult.User;
	using Featurz.Web.ViewModel.User;

	public class UserModelHelper
	{
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

		//public static UserEditVm ToUserEditVm(GetUserQueryResult result)
		//{
		//	if (result == null)
		//	{
		//		throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
		//	}

		//	UserEditVm vm = new UserEditVm();
		//	vm.Id = result.Id;
		//	vm.IsActive = result.IsActive;
		//	vm.IsEnabled = result.IsEnabled;
		//	vm.Name = result.Name;
		//	vm.StrategyId = result.StrategyId;
		//	vm.Ticket = result.Ticket;
		//	vm.UserId = result.UserId;

		//	return vm;
		//}

		public static UserGroupVm ToUserGroupVm(Group result)
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

		public static UserListVm ToUserListVm(GetUsersQueryResult results, IConfiguration config)
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
				UserListItemVm User = ToUserLitsItemVm(result, config);
				vm.Users.Add(User);
			}

			return vm;
		}

		public static UserRoleVm ToUserRoleVm(Role result)
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

		private static UserListItemVm ToUserLitsItemVm(User result, IConfiguration config)
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
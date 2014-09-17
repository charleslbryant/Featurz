namespace Featurz.Web.Model
{
	using System;
	using Archer.Core.Configuration;
	using Featurz.Application.Entity;
	using Featurz.Application.QueryResult;
	using Featurz.Web.ViewModel;

	public class UserModelHelper
	{
		public static UserListItemVm SetActive(UserListItemVm feature, User result)
		{
			if (feature == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "feature"));
			}

			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			if (result.IsActive)
			{
				User.Active = "Active";
				User.ActiveClass = "success";
				return User;
			}

			User.Active = "Inactive";
			User.ActiveClass = "danger";
			return User;
		}

		public static UserEditVm ToUserEditVm(GetUserQueryResult result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			UserEditVm vm = new UserEditVm();
			vm.Id = result.Id;
			vm.IsActive = result.IsActive;
			vm.IsEnabled = result.IsEnabled;
			vm.Name = result.Name;
			vm.StrategyId = result.StrategyId;
			vm.Ticket = result.Ticket;
			vm.UserId = result.UserId;

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

		public static UserOwnerVm ToUserOwnerVm(User result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			UserOwnerVm vm = new UserOwnerVm();
			vm.Id = result.Id;
			vm.Name = result.FirstName + " " + result.LastName;
			return vm;
		}

		private static UserListItemVm ToUserLitsItemVm(User result, IConfiguration config)
		{
			UserListItemVm User = new UserListItemVm();
			User.Id = result.Id;
			feature.Name = result.Name;
			feature.Ticket = result.Ticket;
			string ticketSystemBaseUrl = config.Get<string>("featurz.ticketsystemurl");
			feature.TicketLink = string.Format("{0}{1}", ticketSystemBaseUrl, result.Ticket);
			feature.Owner = result.UserId;
			feature = UserModelHelper.SetActive(feature, result);
			feature.DateAdded = result.DateAdded.ToShortDateString();
			return feature;
		}
	}
}
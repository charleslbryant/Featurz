namespace Featurz.Web.Model
{
	using System;
	using Archer.Core.Configuration;
	using Featurz.Application.CommandResult.Feature;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;
	using Featurz.Application.QueryResult.Feature;
	using Featurz.Web.ViewModel.Feature;

	public class FeatureModelHelper
	{
		public static FeatureVm CommandResultToFeatureVm(FeatureCommandResult result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			FeatureVm vm = new FeatureVm();

			vm.Message = MessagesModel.FormError;

			if (!string.IsNullOrWhiteSpace(result.Message))
			{
				vm.Message = result.Message;
			}

			vm.MessageStyle = MessagesModel.MessageStyles.Error;

			if (!string.IsNullOrWhiteSpace(result.InvalidId))
			{
				vm.IdMessage.Message = MessagesModel.ItemMessage + result.InvalidId;
				vm.IdMessage.Error = MessagesModel.ItemError;
				vm.IdMessage.GroupError = MessagesModel.ItemGroupError;
			}

			if (!string.IsNullOrWhiteSpace(result.InvalidName))
			{
				vm.NameMessage.Message = MessagesModel.ItemMessage + result.InvalidName;
				vm.NameMessage.Error = MessagesModel.ItemError;
				vm.NameMessage.GroupError = MessagesModel.ItemGroupError;
			}

			if (!string.IsNullOrWhiteSpace(result.InvalidTicket))
			{
				vm.TicketMessage.Message = MessagesModel.ItemMessage + result.InvalidTicket;
				vm.TicketMessage.Error = MessagesModel.ItemError;
				vm.TicketMessage.GroupError = MessagesModel.ItemGroupError;
			}

			return vm;
		}

		public static FeatureVm QueryResultToFeatureVm(GetFeatureQueryResult result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			FeatureVm vm = new FeatureVm();

			vm.DateAdded = result.DateAdded;
			vm.Id = result.Id;
			vm.Name = result.Name;
			vm.Ticket = result.Ticket;
			vm.UserId = result.UserId;
			vm.IsActive = result.IsActive;
			vm.IsEnabled = result.IsEnabled;
			vm.StrategyId = result.StrategyId;

			return vm;
		}

		public static FeatureListVm ResultToFeatureListVm(GetFeaturesQueryResult results, IConfiguration config)
		{
			if (results == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "results"));
			}

			if (config == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "config"));
			}

			FeatureListVm vm = new FeatureListVm();
			vm.ItemsFound = results.Features.Count > 0;

			if (!vm.ItemsFound)
			{
				vm.Message = MessagesModel.NoItemsFound;
				vm.MessageStyle = MessagesModel.MessageStyles.Info;
			}

			foreach (var result in results.Features)
			{
				FeatureListItemVm feature = ResultToFeatureListItemVm(result, config);
				vm.Features.Add(feature);
			}

			return vm;
		}

		public static FeatureOwnerVm ResultToFeatureOwnerVm(User result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			FeatureOwnerVm vm = new FeatureOwnerVm();
			vm.Id = result.Id;
			vm.Name = result.FirstName + " " + result.LastName;
			return vm;
		}

		public static FeatureListItemVm SetActive(FeatureListItemVm feature, Feature result)
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
				feature.Active = "Active";
				feature.ActiveClass = "success";
				return feature;
			}

			feature.Active = "Inactive";
			feature.ActiveClass = "danger";
			return feature;
		}

		public static FeatureListItemVm SetEnabled(FeatureListItemVm feature, Feature result)
		{
			if (feature == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "feature"));
			}

			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			if (result.IsEnabled)
			{
				feature.Enabled = "Enabled";
				feature.EnabledClass = "success";
				return feature;
			}

			feature.Enabled = "Disabled";
			feature.EnabledClass = "danger";
			return feature;
		}

		private static FeatureListItemVm ResultToFeatureListItemVm(Feature result, IConfiguration config)
		{
			FeatureListItemVm feature = new FeatureListItemVm();
			feature.Id = result.Id;
			feature.Name = result.Name;
			feature.Ticket = result.Ticket;
			string ticketSystemBaseUrl = config.Get<string>("featurz.ticketsystemurl");
			feature.TicketLink = string.Format("{0}{1}", ticketSystemBaseUrl, result.Ticket);
			feature.Owner = result.UserId;
			feature = FeatureModelHelper.SetActive(feature, result);
			feature.DateAdded = result.DateAdded;
			return feature;
		}
	}
}
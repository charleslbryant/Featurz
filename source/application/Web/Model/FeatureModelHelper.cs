namespace Featurz.Web.Model
{
	using System;
	using Archer.Core.Configuration;
	using Featurz.Application.Entity;
	using Featurz.Application.QueryResult;
	using Featurz.Web.ViewModel;

	public class FeatureModelHelper
	{
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

		public static FeatureEditVm ToFeatureEditVm(GetFeatureQueryResult result)
		{
			if (result == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "result"));
			}

			FeatureEditVm vm = new FeatureEditVm();
			vm.Id = result.Id;
			vm.IsActive = result.IsActive;
			vm.IsEnabled = result.IsEnabled;
			vm.Name = result.Name;
			vm.StrategyId = result.StrategyId;
			vm.Ticket = result.Ticket;
			vm.UserId = result.UserId;

			return vm;
		}

		public static FeatureListVm ToFeatureListVm(GetFeaturesQueryResult results, IConfiguration config)
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
				FeatureListItemVm feature = ToFeatureLitsItemVm(result, config);
				vm.Features.Add(feature);
			}

			return vm;
		}

		public static FeatureOwnerVm ToFeatureOwnerVm(User result)
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

		private static FeatureListItemVm ToFeatureLitsItemVm(Feature result, IConfiguration config)
		{
			FeatureListItemVm feature = new FeatureListItemVm();
			feature.Id = result.Id;
			feature.Name = result.Name;
			feature.Ticket = result.Ticket;
			string ticketSystemBaseUrl = config.Get<string>("featurz.ticketsystemurl");
			feature.TicketLink = string.Format("{0}{1}", ticketSystemBaseUrl, result.Ticket);
			feature.Owner = result.UserId;
			feature = FeatureModelHelper.SetActive(feature, result);
			feature.DateAdded = result.DateAdded.ToShortDateString();
			return feature;
		}
	}
}
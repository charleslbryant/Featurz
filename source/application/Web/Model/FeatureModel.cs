namespace Featurz.Web.Model
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Query;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.CommandResult.Feature;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;
	using Featurz.Application.Query.Feature;
	using Featurz.Application.QueryResult.Feature;
	using Featurz.Web.ViewModel.Feature;

	public class FeatureModel
	{
		private readonly ICommandDispatcher commandDispatcher;
		private readonly IConfiguration config;
		private readonly IQueryDispatcher queryDispatcher;

		public FeatureModel(IConfiguration config, IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
		{
			this.config = config;
			this.queryDispatcher = queryDispatcher;
			this.commandDispatcher = commandDispatcher;
		}

		public FeatureVm AddFeature(FeatureVm vm)
		{
			if (vm == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "vm"));
			}

			AddFeatureCommand command = new AddFeatureCommand(vm.Id, vm.DateAdded, vm.Name, vm.UserId, vm.Ticket, vm.IsActive, vm.IsEnabled, vm.StrategyId);

			FeatureCommandResult result = this.commandDispatcher.Dispatch<AddFeatureCommand, FeatureCommandResult, Feature>(command);

			vm = FeatureModelHelper.CommandResultToFeatureVm(result);

			return vm;
		}

		//TODO: Decide what happens if we happen to have a duplicate key here.
		public FeatureVm EditFeature(FeatureVm vm)
		{
			if (vm == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "vm"));
			}

			EditFeatureCommand command = new EditFeatureCommand(vm.Id, vm.DateAdded, vm.Name, vm.UserId, vm.Ticket, vm.IsActive, vm.IsEnabled, vm.StrategyId);

			FeatureCommandResult result = this.commandDispatcher.Dispatch<EditFeatureCommand, FeatureCommandResult, Feature>(command);

			vm = FeatureModelHelper.CommandResultToFeatureVm(result);

			return vm;
		}

		public FeatureVm GetFeatureById(GetFeatureByIdQuery query)
		{
			if (query == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "query"));
			}

			GetFeatureQueryResult result = this.queryDispatcher.Dispatch<GetFeatureByIdQuery, GetFeatureQueryResult, Feature>(query);

			FeatureVm vm = FeatureModelHelper.QueryResultToFeatureVm(result);

			return vm;
		}

		//TODO: Change to only return users with an owner role.
		public ICollection<FeatureOwnerVm> GetFeatureOwners(GetFeatureOwnersQuery query)
		{
			if (query == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "query"));
			}

			ICollection<FeatureOwnerVm> owners = new List<FeatureOwnerVm>();
			GetFeatureOwnersQueryResult results = this.queryDispatcher.Dispatch<GetFeatureOwnersQuery, GetFeatureOwnersQueryResult, User>(query);

			foreach (var user in results.Owners)
			{
				FeatureOwnerVm owner = FeatureModelHelper.ResultToFeatureOwnerVm(user);
				owners.Add(owner);
			}

			return owners;
		}

		public FeatureListVm GetFeatures(GetFeaturesQuery query)
		{
			if (query == null)
			{
				throw new ArgumentNullException(string.Format(MessagesModel.NullValueError, "query"));
			}

			GetFeaturesQueryResult results = this.queryDispatcher.Dispatch<GetFeaturesQuery, GetFeaturesQueryResult, Feature>(query);

			FeatureListVm vm = FeatureModelHelper.ResultToFeatureListVm(results, this.config);

			return vm;
		}
	}
}
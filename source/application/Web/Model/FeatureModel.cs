namespace Featurz.Web.Model
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Query;
	using Featurz.Application.Command;
	using Featurz.Application.Entity;
	using Featurz.Application.Query;
	using Featurz.Application.QueryResult;
	using Featurz.Web.ViewModel;

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

		public AddFeatureCommand AddFeature(AddFeatureCommand command)
		{
			this.ValidateAddFeatureCommand(command);

			if (!command.Valid)
			{
				return command;
			}

			this.commandDispatcher.Dispatch<AddFeatureCommand, Feature>(command);
			return command;
		}

		public ICollection<FeatureOwnerVm> GetFeatureOwners(GetFeatureOwnersQuery query)
		{
			ICollection<FeatureOwnerVm> owners = new List<FeatureOwnerVm>();
			//GetFeatureOwnersQueryResult results = this.queryDispatcher.Dispatch<GetFeatureOwnersQuery, GetFeatureOwnersQueryResult, Feature>(query);
			//owners = results.Owners;
			FeatureOwnerVm owner = new FeatureOwnerVm();
			owner.Id = "charles.bryant";
			owner.Name = "charles.bryant";
			owners.Add(owner);

			owner = new FeatureOwnerVm();
			owner.Id = "darshit.dave";
			owner.Name = "darshit.dave";
			owners.Add(owner);
			return owners;
		}

		public FeatureListVm GetFeatures(GetFeaturesQuery query)
		{
			GetFeaturesQueryResult results = this.queryDispatcher.Dispatch<GetFeaturesQuery, GetFeaturesQueryResult, Feature>(query);

			FeatureListVm vm = FeatureModelHelper.ToFeatureListVm(results, config);

			return vm;
		}

		public FeatureAddVm SetFeatureAddVm(AddFeatureCommand command, FeatureAddVm vm)
		{
			if (command.Valid)
			{
				return vm;
			}

			vm.Message = MessagesModel.FormError;
			vm.MessageStyle = MessagesModel.MessageStyles.Error;

			if (!string.IsNullOrWhiteSpace(command.InvalidName))
			{
				vm.NameMessage = MessagesModel.ItemMessage + command.InvalidName;
				vm.NameError = MessagesModel.ItemError;
				vm.NameGroupError = MessagesModel.ItemGroupError;
			}

			if (!string.IsNullOrWhiteSpace(command.InvalidTicket))
			{
				vm.TicketMessage = MessagesModel.ItemMessage + command.InvalidTicket;
				vm.NameError = MessagesModel.ItemError;
				vm.NameGroupError = MessagesModel.ItemGroupError;
			}

			return vm;
		}

		public AddFeatureCommand ValidateAddFeatureCommand(AddFeatureCommand command)
		{
			if (string.IsNullOrWhiteSpace(command.Name))
			{
				command.Valid = false;
				command.InvalidName = MessagesModel.Required;
			}

			if (command.Name != null && command.Name.Length > 100)
			{
				command.Valid = false;
				command.InvalidName = string.Format(MessagesModel.MaxLength, "100");
			}

			if (command.Ticket != null && command.Ticket.Length > 50)
			{
				command.Valid = false;
				command.InvalidTicket = string.Format(MessagesModel.MaxLength, "50");
			}

			return command;
		}
	}
}
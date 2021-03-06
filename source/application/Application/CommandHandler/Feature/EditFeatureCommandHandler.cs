﻿namespace Featurz.Application.CommandHandler.Feature
{
	using System;
	using Archer.Core.Command;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.CommandResult.Feature;
	using Featurz.Application.Entity;

	public class EditFeatureCommandHandler : BaseCommandHandler<Feature>, ICommandHandler<EditFeatureCommand, FeatureCommandResult, Feature>
	{
		public EditFeatureCommandHandler()
		{
		}

		public FeatureCommandResult Execute(EditFeatureCommand command)
		{
			FeatureCommandResult result = FeatureCommandHandlerHelper.Validate(command, this.WriteRepository, this.ReadRepository);

			if (!result.Valid)
			{
				return result;
			}

			Feature feature = new Feature(command.Id, command.DateAdded, command.Name, command.UserId, command.Ticket, command.IsActive, command.IsEnabled, command.StrategyId);

			this.WriteRepository.Update(feature);

			return result;
		}
	}
}
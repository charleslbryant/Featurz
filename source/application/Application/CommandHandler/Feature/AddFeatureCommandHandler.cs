namespace Featurz.Application.CommandHandler.Feature
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Command;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.Entity;
	using Featurz.Application.Exceptions;

	public class AddFeatureCommandHandler : BaseCommandHandler<Feature>, ICommandHandler<AddFeatureCommand, Feature>
	{
		public AddFeatureCommandHandler()
		{
		}

		public void Execute(AddFeatureCommand command)
		{
			this.Validate(command);

			Feature feature = new Feature(command.Id, command.DateAdded, command.Name, command.UserId, command.Ticket, command.IsActive, command.IsEnabled, command.StrategyId);

			this.WriteRepository.Insert(feature);
		}

		private IList<Feature> GetFeatureByName(string name)
		{
			IList<Feature> features = this.ReadRepository.Where(x => x.Name == name);
			return features;
		}

		private bool IsDuplicateFeatureName(string name)
		{
			return this.GetFeatureByName(name).Count > 0;
		}

		private void Validate(AddFeatureCommand command)
		{
			// TODO: Research how to handle concurrency in MongoDb.
			// I am still a MongoDb newbie so there is probably a better way to handle concurrency issues.
			// For now, if a duplicate feature is found we will throw an exception.
			if (IsDuplicateFeatureName(command.Name))
			{
				throw new DuplicateItemException(string.Format("A feature already exists with the name {0}", command.Name));
			}

			if (this.WriteRepository == null)
			{
				throw new Exception("WriteRespository can not be a null value;");
			}

			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			if (string.IsNullOrWhiteSpace(command.Id))
			{
				throw new ArgumentException("command.Id cannot be null or white space.");
			}
		}
	}
}
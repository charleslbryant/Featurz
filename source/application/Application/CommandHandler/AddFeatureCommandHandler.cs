namespace Featurz.Application.CommandHandler
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Repository;
	using Archer.Infrastructure.Configuration;
	using Archer.Infrastructure.Data.MongoDb;
	using Featurz.Application.Command;
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

			Feature feature = new Feature(command.Id, command.Name, command.UserId, command.Ticket, command.IsActive, command.IsEnabled, command.StrategyId);

			this.WriteRepository.Insert(feature);

			IList<Feature> features = GetFeatureByName(command.Name);

			// TODO: Research how to handle concurrency in MongoDb.
			// I am still a MongoDb newbie so there is probably a better way to handle concurrency issues.
			// For now, if a duplicate feature is found after adding the feature we will delete the feature we added and throw an exception.
			if (features.Count > 1)
			{
				this.WriteRepository.Delete(feature);

				throw new DuplicateItemException(string.Format("A feature already exists with the name {0}", feature.Name));
			}
		}

		private void Validate(AddFeatureCommand command)
		{
			IsDuplicateFeature(command.Name);

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

		private bool IsDuplicateFeature(string name)
		{
			if (this.GetFeatureByName(name).Count > 0)
			{
				throw new DuplicateItemException(string.Format("A feature already exists with the name {0}", name));
			}

			return false;
		}

		private IList<Feature> GetFeatureByName(string name)
		{
			IList<Feature> features = this.ReadRepository.Where(x => x.Name == name);
			return features;
		}
	}
}
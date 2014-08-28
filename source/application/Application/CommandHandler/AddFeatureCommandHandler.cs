namespace Featurz.Application.CommandHandler
{
	using System;
	using Archer.Core.Command;
	using Archer.Core.Repository;
	using Archer.Infrastructure.Configuration;
	using Archer.Infrastructure.Data.MongoDb;
	using Featurz.Application.Command;
	using Featurz.Application.Entity;

	public class AddFeatureCommandHandler : ICommandHandler<AddFeatureCommand>
	{
		private readonly IWriteRepository<Feature> featureRepo;
		private Archer.Core.Configuration.IConfiguration config;

		public AddFeatureCommandHandler(IWriteRepository<Feature> featureRepo)
		{
			if (featureRepo == null)
			{
				throw new ArgumentNullException("featureRepo");
			}

			this.featureRepo = featureRepo;
		}

		public AddFeatureCommandHandler()
		{
			this.config = new AppConfig();
			this.featureRepo = new MongoWriteRepository<Feature>(config);
		}

		public void Execute(AddFeatureCommand command)
		{
			this.Validate(command);
			Feature feature = new Feature(command.Id, command.Name, command.UserId, command.Ticket, command.IsActive, command.IsEnabled, command.StrategyId);
			this.featureRepo.Insert(feature);
		}

		private void Validate(AddFeatureCommand command)
		{
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
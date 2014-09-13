namespace Featurz.Application.CommandHandler
{
	using System;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Repository;
	using Archer.Infrastructure.Configuration;
	using Archer.Infrastructure.Data.MongoDb;
	using Featurz.Application.Command;
	using Featurz.Application.Entity;

	public class AddFeatureCommandHandler : ICommandHandler<AddFeatureCommand, Feature>
	{
		public AddFeatureCommandHandler()
		{
		}

		public void Execute(AddFeatureCommand command)
		{
			this.Validate(command);
			Feature feature = new Feature(command.Id, command.Name, command.UserId, command.Ticket, command.IsActive, command.IsEnabled, command.StrategyId);
			this.WriteRepository.Insert(feature);
		}

		private void Validate(AddFeatureCommand command)
		{
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
		public IConfiguration Config { get; set; }

		public IReadRepository<Feature> ReadRepository { get; set; }

		public IWriteRepository<Feature> WriteRepository { get; set; }
	}
}
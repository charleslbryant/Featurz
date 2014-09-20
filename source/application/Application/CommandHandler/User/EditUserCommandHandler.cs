namespace Featurz.Application.CommandHandler.User
{
	using System;
	using Archer.Core.Command;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.Entity;

	public class EditUserCommandHandler : BaseCommandHandler<Feature>, ICommandHandler<EditFeatureCommand, Feature>
	{
		public EditFeatureCommandHandler()
		{
		}

		public void Execute(EditFeatureCommand command)
		{
			this.Validate(command);

			Feature feature = new Feature(command.Id, command.Name, command.UserId, command.Ticket, command.IsActive, command.IsEnabled, command.StrategyId);

			this.WriteRepository.Update(feature);
		}

		private void Validate(EditFeatureCommand command)
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
	}
}
namespace Featurz.Application.CommandHandler.Feature
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Repository;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.CommandResult.Feature;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;

	public class FeatureCommandHandlerHelper
	{
		public static FeatureCommandResult Validate(FeatureCommand command, IWriteRepository<Feature> write, IReadRepository<Feature> read)
		{
			if (write == null)
			{
				throw new Exception("WriteRespository can not be a null value.");
			}

			if (read == null)
			{
				throw new Exception("ReadRespository can not be a null value.");
			}

			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			FeatureCommandResult result = new FeatureCommandResult();

			result.Valid = true;

			if (string.IsNullOrWhiteSpace(command.Id))
			{
				result.Valid = false;
				result.InvalidName = MessagesModel.Required;
			}

			if (string.IsNullOrWhiteSpace(command.Name))
			{
				result.Valid = false;
				result.InvalidName = MessagesModel.Required;
			}

			if (command.Name != null && command.Name.Length > 100)
			{
				result.Valid = false;
				result.InvalidName = string.Format(MessagesModel.MaxLength, "100");
			}

			if (command.Ticket != null && command.Ticket.Length > 100)
			{
				result.Valid = false;
				result.InvalidTicket = string.Format(MessagesModel.MaxLength, "100");
			}

			return result;
		}

		private static IList<Feature> GetFeatureByName(string name, IReadRepository<Feature> read)
		{
			IList<Feature> features = read.Where(x => x.Name == name);
			return features;
		}

		public static bool IsDuplicateName(string name, IReadRepository<Feature> read)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return false;
			}

			return FeatureCommandHandlerHelper.GetFeatureByName(name, read).Count > 0;
		}
	}
}
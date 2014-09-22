namespace Featurz.Application.CommandResult.Feature
{
	using System;

	public class FeatureCommandResult : CommandResultBase
	{
		public FeatureCommandResult()
		{
		}

		public string InvalidId { get; set; }

		public string InvalidName { get; set; }

		public string InvalidTicket { get; set; }
	}
}
namespace Featurz.Application.Tests.Unit.CommandHandler.Feature
{
	using System;
	using Featurz.Application.Command.Feature;

	public class FeatureCommandHandlerTestHelper
	{
		public static FeatureCommand GetCommand(string name = null, string ticket = null, string id = null)
		{
			string defaultId = "id1";
			string defaultName = "Feature 1";
			string defaultTicket = "ticket1";
			DateTime date = DateTime.Now;
			string user = "tester";

			id = id ?? defaultId;
			name = name ?? defaultName;
			ticket = ticket ?? defaultTicket;

			FeatureCommand command = new FeatureCommand(id, date, name, user, ticket);
			return command;
		}

		public static AddFeatureCommand GetAddCommand(string name = null, string ticket = null, string id = null)
		{
			string defaultId = "id1";
			string defaultName = "Feature 1";
			string defaultTicket = "ticket1";
			DateTime date = DateTime.Now;
			string user = "tester";

			id = id ?? defaultId;
			name = name ?? defaultName;
			ticket = ticket ?? defaultTicket;

			AddFeatureCommand command = new AddFeatureCommand(id, date, name, user, ticket);
			return command;
		}

		public static EditFeatureCommand GetEditCommand(string name = null, string ticket = null, string id = null)
		{
			string defaultId = "id1";
			string defaultName = "Feature 1";
			string defaultTicket = "ticket1";
			DateTime date = DateTime.Now;
			string user = "tester";

			id = id ?? defaultId;
			name = name ?? defaultName;
			ticket = ticket ?? defaultTicket;

			EditFeatureCommand command = new EditFeatureCommand(id, date, name, user, ticket);
			return command;
		}
	}
}
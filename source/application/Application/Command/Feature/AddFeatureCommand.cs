namespace Featurz.Application.Command.Feature
{
	using System;

	public class AddFeatureCommand : FeatureCommand
	{
		public AddFeatureCommand(string id, DateTime dateAdded, string name, string userId, string ticket = "", bool isActive = false, bool isEnabled = false, int strategyId = 0)
			: base(id, dateAdded, name, userId, ticket, isActive, isEnabled, strategyId)
		{
		}
	}
}
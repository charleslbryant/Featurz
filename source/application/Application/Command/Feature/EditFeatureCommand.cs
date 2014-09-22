namespace Featurz.Application.Command.Feature
{
	using System;

	public class EditFeatureCommand : FeatureCommand
	{
		public EditFeatureCommand(string id, DateTime dateAdded, string name, string userId, string ticket = "", bool isActive = false, bool isEnabled = false, int strategyId = 0)
			: base(id, dateAdded, name, userId, ticket, isActive, isEnabled, strategyId)
		{
		}
	}
}
namespace Featurz.Admin.ApiControllers
{
	using System;

	public class AddFeatureVm
	{
		public bool IsActive { get; set; }

		public bool IsEnabled { get; set; }

		public string Name { get; set; }

		public int StrategyId { get; set; }

		public string Ticket { get; set; }

		public string UserId { get; set; }
	}
}
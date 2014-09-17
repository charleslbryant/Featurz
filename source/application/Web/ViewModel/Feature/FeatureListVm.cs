namespace Featurz.Web.ViewModel.Feature
{
	using System;
	using System.Collections.Generic;

	public class FeatureListVm : BaseVm
	{
		public FeatureListVm()
		{
			this.Features = new List<FeatureListItemVm>();
		}

		public ICollection<FeatureListItemVm> Features { get; set; }

		public bool ItemsFound { get; set; }
	}
}
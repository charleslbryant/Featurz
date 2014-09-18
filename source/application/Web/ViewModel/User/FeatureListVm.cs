namespace Featurz.Web.ViewModel.User
{
	using System;
	using System.Collections.Generic;
	using Featurz.Web.Model;

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
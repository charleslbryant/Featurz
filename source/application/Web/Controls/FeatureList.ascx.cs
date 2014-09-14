namespace Featurz.Web.Controls
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Query;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel;

	public partial class FeatureList : BaseUserControl
	{
		private static readonly string DefaultSort = "Name";
		private static readonly SortDirection DefaultSortDirection = SortDirection.Ascending;

		private FeatureModel model;
		private GetFeaturesQuery query;

		public FeatureList()
		{
			this.Vm = new FeatureListVm();
			this.model = new FeatureModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
		}

		public FeatureListVm Vm { get; private set; }

		protected void GoAddFeature(object sendder, EventArgs e)
		{
			this.Navigate(PagesModel.FeaturesAdd);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.query = new GetFeaturesQuery(this.FeatureGrid.PageSize, 1, FeatureList.DefaultSort, FeatureList.DefaultSortDirection);
				this.Bind();
			}
		}

		protected void SearchFeatures(object sendder, EventArgs e)
		{
		}

		private void Bind()
		{
			this.Vm = this.model.GetFeatures(this.query);
			this.FeatureGrid.Visible = this.Vm.ItemsFound;
			this.BindGrid(this.Vm.Features);
		}

		private void BindGrid(ICollection<FeatureListItemVm> features)
		{
			this.FeatureGrid.DataSource = features;
			this.FeatureGrid.DataBind();
		}
	}
}
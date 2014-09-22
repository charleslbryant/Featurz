namespace Featurz.Web.Controls.Features
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.Query.Feature;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.Feature;

	public partial class Add : BaseUserControl
	{
		private FeatureModel model;

		public Add()
		{
			this.Vm = new FeatureVm();
			this.model = new FeatureModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
			this.PageTitle = "Add Feature";
		}

		public FeatureVm Vm { get; private set; }

		protected void CancelForm(object sendder, EventArgs e)
		{
			this.Navigate(PagesModel.Features);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.Bind();
			}
		}

		protected void SubmitForm(object sender, EventArgs e)
		{
			this.ControlToViewModel(this.Vm);

			this.Vm = this.model.AddFeature(this.Vm);

			if (this.Vm.Valid)
			{
				this.Navigate(PagesModel.Features);
			}

			this.ViewModelToControl(this.Vm);
		}

		private void Bind()
		{
			GetFeatureOwnersQuery query = new GetFeatureOwnersQuery(0, 1, "Id", SortDirection.Ascending);

			ICollection<FeatureOwnerVm> owners = this.model.GetFeatureOwners(query);
			this.FeatureOwner.DataTextField = "Name";
			this.FeatureOwner.DataValueField = "Id";
			this.FeatureOwner.DataSource = owners;
			this.FeatureOwner.DataBind();

			this.FeatureOwner.Items.Insert(0, "Select Owner");
			this.FeatureOwner.SelectedIndex = 0;
		}

		private void ControlToViewModel(FeatureVm vm)
		{
			vm.Id = Guid.NewGuid().ToString();
			vm.DateAdded = DateTime.Now;
			vm.Name = this.FeatureName.Text;
			vm.Ticket = this.FeatureTicket.Text;
			vm.UserId = this.FeatureOwner.SelectedValue;
			vm.IsActive = this.FeatureActive.Checked;
			vm.IsEnabled = this.FeatureEnabled.Checked;
		}

		private FeatureCommand GetAddFeatureCommand()
		{
			string id = Guid.NewGuid().ToString();
			DateTime date = DateTime.Now;
			string name = this.FeatureName.Text;
			string ticket = this.FeatureTicket.Text;
			string owner = this.FeatureOwner.SelectedValue;
			bool active = this.FeatureActive.Checked;
			bool enabled = this.FeatureEnabled.Checked;

			return new FeatureCommand(id, date, name, owner, ticket, active, enabled, 0);
		}

		private void ViewModelToControl(FeatureVm vm)
		{
			this.FeatureName.Text = vm.Name;
			this.FeatureTicket.Text = vm.Ticket;
			this.FeatureOwner.SelectedValue = vm.UserId;
			this.FeatureActive.Checked = vm.IsActive;
			this.FeatureEnabled.Checked = vm.IsEnabled;
		}
	}
}
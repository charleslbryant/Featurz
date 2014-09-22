namespace Featurz.Web.Controls.Features
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Query.Feature;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.Feature;

	public partial class Edit : BaseUserControl
	{
		private FeatureModel model;

		public Edit()
		{
			this.Vm = new FeatureVm();
			this.model = new FeatureModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
			this.PageTitle = "Edit Feature";
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

			this.Vm = this.model.EditFeature(this.Vm);

			if (this.Vm.Valid)
			{
				this.Navigate(PagesModel.Users);
			}

			this.ViewModelToControl(this.Vm);
		}

		private void Bind()
		{
			this.BindFeatureOwner();
			this.BindFormValues();
		}

		private void BindFeatureOwner()
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

		private void BindFormValues()
		{
			string id = Request.QueryString["id"];
			GetFeatureByIdQuery query = new GetFeatureByIdQuery(id);
			this.Vm = this.model.GetFeatureById(query);

			this.FeatureId.Text = this.Vm.Id;
			this.FeatureName.Text = this.Vm.Name;
			this.FeatureTicket.Text = this.Vm.Ticket;
			this.FeatureOwner.SelectedValue = this.Vm.UserId;
			this.FeatureActive.Checked = this.Vm.IsActive;
			this.FeatureEnabled.Checked = this.Vm.IsEnabled;
			this.FeatureDateAdded.Text = this.Vm.DateAdded.ToShortDateString();
		}

		private void ControlToViewModel(FeatureVm vm)
		{
			vm.Id = this.FeatureId.Text;
			DateTime date = DateTime.Parse(this.FeatureDateAdded.Text);
			vm.Name = this.FeatureName.Text;
			vm.Ticket = this.FeatureTicket.Text;
			vm.UserId = this.FeatureOwner.SelectedValue;
			vm.IsActive = this.FeatureActive.Checked;
			vm.IsEnabled = this.FeatureEnabled.Checked;
		}

		private void ViewModelToControl(FeatureVm vm)
		{
			this.FeatureId.Text = vm.Id;
			this.FeatureDateAdded.Text = vm.DateAdded.ToShortDateString();
			this.FeatureName.Text = vm.Name;
			this.FeatureTicket.Text = vm.Ticket;
			this.FeatureOwner.SelectedValue = vm.UserId;
			this.FeatureActive.Checked = vm.IsActive;
			this.FeatureEnabled.Checked = vm.IsEnabled;
		}
	}
}
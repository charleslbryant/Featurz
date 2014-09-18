namespace Featurz.Web.Controls.Features
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.Query.Feature;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.Feature;

	public partial class Edit : BaseUserControl
	{
		private FeatureModel model;

		public Edit()
		{
			this.Vm = new FeatureEditVm();
			this.model = new FeatureModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
			this.PageTitle = "Edit Feature";
		}

		public FeatureEditVm Vm { get; private set; }

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
			EditFeatureCommand command = this.GetEditFeatureCommand();

			command = this.model.EditFeature(command);

			if (command.Valid)
			{
				this.Navigate(PagesModel.Features);
			}

			this.Vm = this.model.SetFeatureEditVm(command, this.Vm);
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
		}

		private EditFeatureCommand GetEditFeatureCommand()
		{
			string id = this.FeatureId.Text;
			string name = this.FeatureName.Text;
			string ticket = this.FeatureTicket.Text;
			string owner = this.FeatureOwner.SelectedValue;
			bool active = this.FeatureActive.Checked;
			bool enabled = this.FeatureEnabled.Checked;

			return new EditFeatureCommand(id, name, owner, ticket, active, enabled, 0);
		}
	}
}
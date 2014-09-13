namespace Featurz.Web.Controls
{
	using System;
	using System.Collections.Generic;
	using Featurz.Application.Command;
	using Featurz.Application.Query;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel;

	public partial class FeatureAdd : BaseUserControl
	{
		private FeatureModel model;

		public FeatureAdd()
		{
			this.Vm = new FeatureAddVm();
			this.model = new FeatureModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
		}

		public FeatureAddVm Vm { get; private set; }

		protected void CancelForm(object sendder, EventArgs e)
		{
			Response.Redirect(PagesModel.Features);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Bind();
		}

		protected void SubmitForm(object sender, EventArgs e)
		{
			AddFeatureCommand command = this.GetAddFeatureCommand();

			command = this.model.AddFeature(command);

			if (command.Valid)
			{
				Response.Redirect(PagesModel.Features);
			}

			this.Vm = this.model.SetFeatureAddVm(command, this.Vm);
		}

		private void Bind()
		{
			GetFeatureOwnersQuery query = new GetFeatureOwnersQuery();

			ICollection<FeatureOwnerVm> owners = this.model.GetFeatureOwners(query);
			this.FeatureOwner.DataTextField = "Name";
			this.FeatureOwner.DataValueField = "Id";
			this.FeatureOwner.DataSource = owners;
			this.FeatureOwner.DataBind();

			this.FeatureOwner.Items.Insert(0, "Select Owner");
			this.FeatureOwner.SelectedIndex = 0;
		}

		private AddFeatureCommand GetAddFeatureCommand()
		{
			string id = Guid.NewGuid().ToString();
			string name = this.FeatureName.Text;
			string ticket = this.FeatureTicket.Text;
			string owner = Request.Form["ctl00$MainContent$FeatureAdd$FeatureOwner"];
			bool active = this.FeatureActive.Checked;
			bool enabled = this.FeatureEnabled.Checked;

			return new AddFeatureCommand(id, name, owner, ticket, active, enabled, 0);
		}
	}
}
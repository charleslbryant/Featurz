namespace Featurz.Web.Controls.Users
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Command;
	using Featurz.Application.Query;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel;

	public partial class Edit : BaseUserControl
	{
		private UserModel model;

		public Edit()
		{
			this.Vm = new UserEditVm();
			this.model = new UserModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
		}

		public UserEditVm Vm { get; private set; }

		protected void CancelForm(object sendder, EventArgs e)
		{
			this.Navigate(PagesModel.Users);
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
			EditUserCommand command = this.GetEditUserCommand();

			command = this.model.EditUser(command);

			if (command.Valid)
			{
				this.Navigate(PagesModel.Users);
			}

			this.Vm = this.model.SetUserEditVm(command, this.Vm);
		}

		private void Bind()
		{
			BindUserOwner();
			BindFormValues();
		}

		private void BindFormValues()
		{
			string id = Request.QueryString["id"];
			GetUserByIdQuery query = new GetUserByIdQuery(id);
			this.Vm = this.model.GetUserById(query);

			this.UserId.Text = this.Vm.Id;
			this.UserName.Text = this.Vm.Name;
			this.UserTicket.Text = this.Vm.Ticket;
			this.UserOwner.SelectedValue = this.Vm.UserId;
			this.UserActive.Checked = this.Vm.IsActive;
			this.UserEnabled.Checked = this.Vm.IsEnabled;
		}

		private void BindUserOwner()
		{
			GetUserOwnersQuery query = new GetUserOwnersQuery(0, 1, "Id", SortDirection.Ascending);

			ICollection<UserOwnerVm> owners = this.model.GetUserOwners(query);
			this.UserOwner.DataTextField = "Name";
			this.UserOwner.DataValueField = "Id";
			this.UserOwner.DataSource = owners;
			this.UserOwner.DataBind();

			this.UserOwner.Items.Insert(0, "Select Owner");
			this.UserOwner.SelectedIndex = 0;
		}

		private EditUserCommand GetEditUserCommand()
		{
			string id = this.UserId.Text;
			string name = this.UserName.Text;
			string ticket = this.UserTicket.Text;
			string owner = this.UserOwner.SelectedValue;
			bool active = this.UserActive.Checked;
			bool enabled = this.UserEnabled.Checked;

			return new EditUserCommand(id, name, owner, ticket, active, enabled, 0);
		}
	}
}
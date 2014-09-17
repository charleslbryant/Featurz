namespace Featurz.Web.Controls.Users
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Command;
	using Featurz.Application.Query;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel;

	public partial class Add : BaseUserControl
	{
		private UserModel model;

		public Add()
		{
			this.Vm = new UserAddVm();
			this.model = new UserModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
		}

		public UserAddVm Vm { get; private set; }

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
			AddUserCommand command = this.GetAddUserCommand();

			command = this.model.AddUser(command);

			if (command.Valid)
			{
				this.Navigate(PagesModel.Users);
			}

			this.Vm = this.model.SetUserAddVm(command, this.Vm);
		}

		private void Bind()
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

		private AddUserCommand GetAddUserCommand()
		{
			string id = Guid.NewGuid().ToString();
			string name = this.UserName.Text;
			string ticket = this.UserTicket.Text;
			string owner = this.UserOwner.SelectedValue;
			bool active = this.UserActive.Checked;
			bool enabled = this.UserEnabled.Checked;

			return new AddUserCommand(id, name, owner, ticket, active, enabled, 0);
		}
	}
}
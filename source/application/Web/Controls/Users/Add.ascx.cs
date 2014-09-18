namespace Featurz.Web.Controls.Users
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Command;
	using Featurz.Application.Query.User;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.User;

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
			this.BindUserRoles();
			this.BindUserGroups();
		}

		private void BindUserGroups()
		{
			GetUserGroupsQuery query = new GetUserGroupsQuery(0, 1, "Id", SortDirection.Ascending);

			ICollection<UserGroupVm> owners = this.model.GetUserGroups(query);
			this.UserGroups.DataTextField = "Name";
			this.UserGroups.DataValueField = "Id";
			this.UserGroups.DataSource = owners;
			this.UserGroups.DataBind();

			this.UserGroups.Items.Insert(0, "Select Owner");
			this.UserGroups.SelectedIndex = 0;
		}

		private void BindUserRoles()
		{
			GetUserRolesQuery query = new GetUserRolesQuery(0, 1, "Id", SortDirection.Ascending);

			ICollection<UserRoleVm> owners = this.model.GetUserRoles(query);
			this.UserRoles.DataTextField = "Name";
			this.UserRoles.DataValueField = "Id";
			this.UserRoles.DataSource = owners;
			this.UserRoles.DataBind();

			this.UserRoles.Items.Insert(0, "Select Owner");
			this.UserRoles.SelectedIndex = 0;
		}

		private AddUserCommand GetAddUserCommand()
		{
			string id = Guid.NewGuid().ToString();
			string firstName = this.FirstName.Text;
			string lastName = this.LastName.Text;
			string email = this.Email.Text;
			ICollection<string> roles = new List<string>();
			ICollection<string> groups = new List<string>();
			bool isEnabled = this.IsEnabled.Checked;

			return new AddUserCommand(id, firstName, lastName, email, roles, groups, isEnabled);
		}
	}
}
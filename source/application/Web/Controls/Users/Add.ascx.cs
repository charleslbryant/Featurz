namespace Featurz.Web.Controls.Users
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Query.User;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.User;

	public partial class Add : BaseUserControl
	{
		private UserModel model;

		public Add()
		{
			this.Vm = new UserVm();
			this.model = new UserModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
			this.PageTitle = "Add User";
		}

		public UserVm Vm { get; private set; }

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
			this.ControlToViewModel(this.Vm);

			this.Vm = this.model.AddUser(this.Vm);

			if (this.Vm.Valid)
			{
				this.Navigate(PagesModel.Users);
			}

			this.ViewModelToControl(this.Vm);
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
		}

		private void BindUserRoles()
		{
			GetUserRolesQuery query = new GetUserRolesQuery(0, 1, "Id", SortDirection.Ascending);

			ICollection<UserRoleVm> owners = this.model.GetUserRoles(query);
			this.UserRoles.DataTextField = "Name";
			this.UserRoles.DataValueField = "Id";
			this.UserRoles.DataSource = owners;
			this.UserRoles.DataBind();
		}

		private void ControlToViewModel(UserVm vm)
		{
			vm.Id = this.Username.Text;
			vm.DateAdded = DateTime.Now;
			vm.FirstName = this.UserFirstName.Text;
			vm.LastName = this.UserLastName.Text;
			vm.Email = this.UserEmail.Text;
			ICollection<string> roles = new List<string>();
			vm.Roles = roles;
			ICollection<string> groups = new List<string>();
			vm.Groups = groups;
			vm.IsEnabled = this.UserIsEnabled.Checked;
		}

		private void ViewModelToControl(UserVm vm)
		{
			this.Username.Text = vm.Username;
			//this.UserDateAdded.Text = vm.DateAdded.ToShortDateString();
			this.UserFirstName.Text = vm.FirstName;
			this.UserLastName.Text = vm.LastName;
			this.UserEmail.Text = vm.Email;
			//this.UserRoles = null;
			//this.UserGroups = null;
			this.UserIsEnabled.Checked = vm.IsEnabled;
		}
	}
}
namespace Featurz.Web.Controls.Users
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Query.User;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.User;

	public partial class Edit : BaseUserControl
	{
		private UserModel model;

		public Edit()
		{
			this.Vm = new UserVm();
			this.model = new UserModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
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

			this.Vm = this.model.EditUser(this.Vm);

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
			this.BindFormFields();
		}

		private void BindFormFields()
		{
			this.Vm.Id = Request.QueryString["id"];
			this.Vm = this.model.GetUserById(this.Vm);
			this.ViewModelToControl(this.Vm);
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

		private void BindUserOwner()
		{
			GetUserGroupsQuery query = new GetUserGroupsQuery(0, 1, "Id", SortDirection.Ascending);

			ICollection<UserGroupVm> groups = this.model.GetUserGroups(query);
			this.UserGroups.DataTextField = "Name";
			this.UserGroups.DataValueField = "Id";
			this.UserGroups.DataSource = groups;
			this.UserGroups.DataBind();
		}

		private void BindUserRoles()
		{
			GetUserRolesQuery query = new GetUserRolesQuery(0, 1, "Id", SortDirection.Ascending);

			ICollection<UserRoleVm> roles = this.model.GetUserRoles(query);
			this.UserRoles.DataTextField = "Name";
			this.UserRoles.DataValueField = "Id";
			this.UserRoles.DataSource = roles;
			this.UserRoles.DataBind();
		}

		private void ControlToViewModel(UserVm vm)
		{
			vm.Id = this.Username.Text;
			DateTime date = DateTime.MinValue;
			DateTime.TryParse(this.UserDateAdded.Text, out date);
			vm.DateAdded = date;
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
			this.UserDateAdded.Text = vm.DateAdded.ToShortDateString();
			this.UserFirstName.Text = vm.FirstName;
			this.UserLastName.Text = vm.LastName;
			this.UserEmail.Text = vm.Email;
			//this.UserRoles = null;
			//this.UserGroups = null;
			this.UserIsEnabled.Checked = vm.IsEnabled;
		}
	}
}
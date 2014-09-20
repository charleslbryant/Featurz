namespace Featurz.Web.Controls.Users
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Query.User;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.User;

	public partial class List : BaseUserControl
	{
		private static readonly string DefaultSort = "Name";
		private static readonly SortDirection DefaultSortDirection = SortDirection.Ascending;

		private UserModel model;
		private GetUsersQuery query;

		public List()
		{
			this.Vm = new UserListVm();
			this.model = new UserModel(this.Config, this.QueryDispatcher, this.CommandDispatcher);
		}

		public UserListVm Vm { get; private set; }

		protected void GoAddUser(object sendder, EventArgs e)
		{
			this.Navigate(PagesModel.UsersAdd);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				this.query = new GetUsersQuery(this.UserGrid.PageSize, 1, List.DefaultSort, List.DefaultSortDirection);
				this.Bind();
			}
		}

		protected void SearchUsers(object sendder, EventArgs e)
		{
		}

		private void Bind()
		{
			this.Vm = this.model.GetUsers(this.query);
			this.UserGrid.Visible = this.Vm.ItemsFound;
			this.BindGrid(this.Vm.Users);
		}

		private void BindGrid(ICollection<UserListItemVm> Users)
		{
			this.UserGrid.DataSource = Users;
			this.UserGrid.DataBind();
		}
	}
}
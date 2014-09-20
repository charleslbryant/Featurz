namespace Featurz.Web.ViewModel.User
{
	using System;
	using System.Collections.Generic;

	public class UserListVm : BaseVm
	{
		public UserListVm()
		{
			this.Users = new List<UserListItemVm>();
		}

		public bool ItemsFound { get; set; }

		public ICollection<UserListItemVm> Users { get; set; }
	}
}
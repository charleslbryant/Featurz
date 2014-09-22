namespace Featurz.Web.Tests.Unit.Model
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Configuration;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;
	using Featurz.Application.QueryResult.User;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.User;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;

	[TestClass]
	public class UserModelHelperTest
	{
		[TestClass]
		public class SetEnabledTest : UserModelHelperTestBase
		{
			[TestMethod]
			public void SetEnabled_Should_Set_Disabled_When_User_Is_Disabled()
			{
				UserListItemVm user = new UserListItemVm();
				User result = this.GetUser(false);

				UserListItemVm actual = UserModelHelper.SetEnabled(user, result);

				Assert.AreEqual("Disabled", actual.Enabled);
				Assert.AreEqual("danger", actual.EnabledClass);
			}

			[TestMethod]
			public void SetEnabled_Should_Set_Enabled_When_User_Is_Enabled()
			{
				UserListItemVm user = new UserListItemVm();
				User result = this.GetUser();

				UserListItemVm actual = UserModelHelper.SetEnabled(user, result);

				Assert.AreEqual("Enabled", actual.Enabled);
				Assert.AreEqual("success", actual.EnabledClass);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void SetEnabled_Should_Throw_Exception_When_Result_Is_Null()
			{
				UserListItemVm user = new UserListItemVm();
				User result = null;

				UserListItemVm actual = UserModelHelper.SetEnabled(user, result);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void SetEnabled_Should_Throw_Exception_When_User_Is_Null()
			{
				UserListItemVm user = null;
				User result = this.GetUser();

				UserListItemVm actual = UserModelHelper.SetEnabled(user, result);
			}
		}

		//[TestClass]
		//public class ToUserEditVmTest : UserModelHelperTestBase
		//{
		//	[TestMethod]
		//	public void ToUserEditVm_Should_Return_UserEditVm()
		//	{
		//		string id = "1";
		//		string name = "Test User";
		//		string userId = "testuser";
		//		string ticket = "T1";
		//		bool active = true;
		//		bool enabled = true;
		//		int strategyId = 0;

		//		GetUserQueryResult result = new GetUserQueryResult(id, name, userId, ticket, active, enabled, strategyId);

		//		UserEditVm actual = UserModelHelper.ToUserEditVm(result);

		//		Assert.AreEqual(id, actual.Id);
		//		Assert.AreEqual(name, actual.Name);
		//		Assert.AreEqual(userId, actual.UserId);
		//		Assert.AreEqual(ticket, actual.Ticket);
		//		Assert.AreEqual(active, actual.IsActive);
		//		Assert.AreEqual(enabled, actual.IsEnabled);
		//		Assert.AreEqual(strategyId, actual.StrategyId);
		//	}

		//	[TestMethod]
		//	[ExpectedException(typeof(ArgumentNullException))]
		//	public void ToUserEditVm_Should_Throw_Exception_When_Result_Is_Null()
		//	{
		//		GetUserQueryResult result = null;

		//		UserEditVm actual = UserModelHelper.ToUserEditVm(result);
		//	}
		//}

		[TestClass]
		public class ToUserGroupVmTest : UserModelHelperTestBase
		{
			[TestMethod]
			public void ToUserGroupVm_Should_Return_UserGroupVm()
			{
				Group result = new Group("1", "admin", null);

				UserGroupVm actual = UserModelHelper.ResultToUserGroupVm(result);

				Assert.AreEqual("admin", actual.Name);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ToUserGroupVm_Should_Throw_Exception_When_Result_Is_Null()
			{
				Group result = null;

				UserGroupVm actual = UserModelHelper.ResultToUserGroupVm(result);
			}
		}

		[TestClass]
		public class ToUserListVmTest : UserModelHelperTestBase
		{
			[TestMethod]
			public void ToUserListVm_Should_Return_UserListVm_When_Items_Found()
			{
				DateTime date = DateTime.Now;
				ICollection<User> users = new List<User>();
				User user = this.GetUser(true, "1");
				users.Add(user);
				user = this.GetUser(true, "2");
				users.Add(user);
				user = this.GetUser(true, "3");
				users.Add(user);
				GetUsersQueryResult results = new GetUsersQueryResult(users);

				IConfiguration config = GetConfig();

				UserListVm actual = UserModelHelper.ResultToUserListVm(results, config);

				Assert.AreEqual(3, actual.Users.Count);
			}

			[TestMethod]
			public void ToUserListVm_Should_Return_UserListVm_When_No_Items_Found()
			{
				ICollection<User> users = new List<User>();
				GetUsersQueryResult results = new GetUsersQueryResult(users);

				IConfiguration config = GetConfig();

				UserListVm actual = UserModelHelper.ResultToUserListVm(results, config);

				Assert.AreEqual(MessagesModel.NoItemsFound, actual.Message);
				Assert.AreEqual(MessagesModel.MessageStyles.Info, actual.MessageStyle);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ToUserListVm_Should_Throw_Exception_When_Config_Is_Null()
			{
				ICollection<User> users = new List<User>();
				GetUsersQueryResult results = new GetUsersQueryResult(users);

				IConfiguration config = null;

				UserListVm actual = UserModelHelper.ResultToUserListVm(results, config);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ToUserListVm_Should_Throw_Exception_When_Results_Is_Null()
			{
				GetUsersQueryResult results = null;

				IConfiguration config = GetConfig();

				UserListVm actual = UserModelHelper.ResultToUserListVm(results, config);
			}

			private static IConfiguration GetConfig()
			{
				IConfiguration config = Substitute.For<IConfiguration>();
				return config;
			}
		}

		[TestClass]
		public class ToUserRoleVmTest : UserModelHelperTestBase
		{
			[TestMethod]
			public void ToUserRoleVm_Should_Return_UserRoleVm()
			{
				Role result = new Role("1", "admin");

				UserRoleVm actual = UserModelHelper.ResultToUserRoleVm(result);

				Assert.AreEqual("admin", actual.Name);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ToUserRoleVm_Should_Throw_Exception_When_Result_Is_Null()
			{
				Role result = null;

				UserRoleVm actual = UserModelHelper.ResultToUserRoleVm(result);
			}
		}
	}

	public class UserModelHelperTestBase
	{
		protected User GetUser(bool? active = null, string id = "1")
		{
			bool defaultActive = active ?? true;

			User user = new User(id, DateTime.Now, "test@abc.comx", "First1", "Last1", null, null, defaultActive);
			return user;
		}
	}
}
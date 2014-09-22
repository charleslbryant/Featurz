namespace Featurz.Web.Tests.Unit.Model
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Entity;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.User;
	using Featurz.Application.QueryResult.User;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.User;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;

	[TestClass]
	public class UserModelTest
	{
		//TODO test catching of dispatcher exceptions
		[TestClass]
		public class AddUserTest : UserModelTestBase
		{
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void AddUser_Should_Throws_Exception_When_Command_Null()
			{
				UserVm vm = null;

				var actual = this.Sut.AddUser(vm);
			}

			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}
		}

		//TODO test catching of dispatcher exceptions
		//[TestClass]
		//public class EditUserTest : UserModelTestBase
		//{
		//	[TestMethod]
		//	public void EditUser_Should_Edit_User()
		//	{
		//		string id = "id1";
		//		string firstName = "User 1";
		//		string lastName = "User 1";
		//		string email = "tester@abc.comx";
		//		ICollection<string> roles = null;
		//		ICollection<string> groups = null;
		//		bool isEnabled = true;

		//		EditUserCommand vm = new EditUserCommand(id, name, userId);

		//		this.Sut.EditUser(vm);

		//		var calls = this.CommandDispatch.ReceivedCalls();
		//		ICall call = calls.First();
		//		string called = call.GetMethodInfo().Name;
		//		Assert.AreEqual(1, calls.Count());
		//		Assert.AreEqual("Dispatch", called);
		//	}

		//	[TestMethod]
		//	public void EditUser_Should_Not_Edit_User_When_Command_Is_Invalid()
		//	{
		//		string id = "id1";
		//		string firstName = "User 1";
		//		string lastName = "User 1";
		//		string email = "tester@abc.comx";
		//		ICollection<string> roles = null;
		//		ICollection<string> groups = null;
		//		bool isEnabled = true;

		//		EditUserCommand vm = new EditUserCommand(id, name, userId);
		//		vm.Valid = false;

		//		this.Sut.EditUser(vm);

		//		var calls = this.CommandDispatch.ReceivedCalls();

		//		Assert.AreEqual(0, calls.Count());
		//	}

		//	[TestMethod]
		//	public void EditUser_Should_Not_Edit_User_When_Name_Has_Invalid_Length()
		//	{
		//		string id = "id1";
		//		string name = "a".PadLeft(101, 'a');
		//		string userId = "tester";

		//		EditUserCommand vm = new EditUserCommand(id, name, userId);

		//		this.Sut.EditUser(vm);

		//		var calls = this.CommandDispatch.ReceivedCalls();

		//		Assert.AreEqual(0, calls.Count());
		//	}

		//	[TestMethod]
		//	public void EditUser_Should_Not_Edit_User_When_No_Name()
		//	{
		//		string id = "id1";
		//		string name = "";
		//		string userId = "tester";

		//		EditUserCommand vm = new EditUserCommand(id, name, userId);

		//		this.Sut.EditUser(vm);

		//		var calls = this.CommandDispatch.ReceivedCalls();

		//		Assert.AreEqual(0, calls.Count());
		//	}

		//	[TestMethod]
		//	public void EditUser_Should_Not_Edit_User_When_Ticket_Has_Invalid_Length()
		//	{
		//		string id = "id1";
		//		string firstName = "User 1";
		//		string lastName = "User 1";
		//		string email = "tester@abc.comx";
		//		ICollection<string> roles = null;
		//		ICollection<string> groups = null;
		//		bool isEnabled = true;
		//		string ticket = "a".PadLeft(101, 'a');

		//		EditUserCommand vm = new EditUserCommand(id, name, userId, ticket);

		//		this.Sut.EditUser(vm);

		//		var calls = this.CommandDispatch.ReceivedCalls();

		//		Assert.AreEqual(0, calls.Count());
		//	}

		//	[TestMethod]
		//	[ExpectedException(typeof(ArgumentNullException))]
		//	public void EditUser_Should_Throws_Exception_When_Command_Null()
		//	{
		//		EditUserCommand vm = null;

		//		var actual = this.Sut.EditUser(vm);
		//	}

		//	[TestInitialize]
		//	public void SetupTest()
		//	{
		//		this.Initialize();
		//	}
		//}

		[TestClass]
		public class GetUsersTest : UserModelTestBase
		{
			[TestMethod]
			public void GetUsers_Should_Get_Users()
			{
				GetUsersQuery query = this.SetQueryDispatcher();

				var actual = this.Sut.GetUsers(query);

				Assert.AreEqual(3, actual.Users.Count);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void GetUsers_Should_Throws_Exception_When_Query_Null()
			{
				GetUsersQuery query = null;

				this.Sut.GetUsers(query);
			}

			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}

			private ICollection<User> GetUsers()
			{
				ICollection<User> users = new List<User>();
				DateTime date = DateTime.Now;
				User user = new User("1", date, "test@abc.comx", "User1", "user1", null, null, true);
				users.Add(user);

				user = new User("2", date, "test@abc.comx", "User1", "user1", null, null, true);
				users.Add(user);

				user = new User("3", date, "test@abc.comx", "User1", "user1", null, null, true);
				users.Add(user);

				return users;
			}

			private GetUsersQuery SetQueryDispatcher()
			{
				GetUsersQuery query = new GetUsersQuery(0, 1, "Name", SortDirection.Ascending);

				ICollection<User> users = GetUsers();
				GetUsersQueryResult results = new GetUsersQueryResult(users);

				this.QueryDispatch.Dispatch<GetUsersQuery, GetUsersQueryResult, User>(query).ReturnsForAnyArgs(results);
				return query;
			}
		}
	}

	public class UserModelTestBase : ModelTestBase
	{
		protected UserModel Sut { get; private set; }

		protected UserVm GetUserVm(string id = null, DateTime? date = null, string firstName = null, string lastName = null, string email = null, ICollection<string> roles = null, ICollection<string> groups = null, bool? isEnabled = null)
		{
			string defaultId = id ?? "id1";
			DateTime defaultDate = date ?? DateTime.Now;
			string defaultFirstName = firstName ?? "UserFirst";
			string defaultLastName = lastName ?? "UserLast";
			string defaultEmail = email ?? "tester@abc.comx";
			ICollection<string> defaultRoles = roles ?? new List<string>();
			ICollection<string> defaultGroups = groups ?? new List<string>();
			bool defaultEnabled = isEnabled ?? true;

			UserVm vm = new UserVm();
			vm.Id = defaultId;
			vm.DateAdded = defaultDate;
			vm.FirstName = defaultFirstName;
			vm.LastName = defaultLastName;
			vm.Email = defaultEmail;
			vm.Roles = defaultRoles;
			vm.Groups = defaultGroups;
			vm.IsEnabled = defaultEnabled;

			return vm;
		}

		protected void Initialize()
		{
			base.InitializeBase();
			this.Sut = new UserModel(this.Config, this.QueryDispatch, this.CommandDispatch);
		}
	}
}
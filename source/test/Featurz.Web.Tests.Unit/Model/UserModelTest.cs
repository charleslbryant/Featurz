namespace Featurz.Web.Tests.Unit.Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Featurz.Application.Command.User;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.User;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;
	using NSubstitute.Core;

	[TestClass]
	public class UserModelTest
	{
		//TODO test catching of dispatcher exceptions
		[TestClass]
		public class AddUserTest : UserModelTestBase
		{
			[TestMethod]
			public void AddUser_Should_Add_User()
			{
				AddUserCommand command = GetAddCommand();

				this.Sut.AddUser(command);

				var calls = this.CommandDispatch.ReceivedCalls();
				ICall call = calls.First();
				string called = call.GetMethodInfo().Name;
				Assert.AreEqual(1, calls.Count());
				Assert.AreEqual("Dispatch", called);
			}

			[TestMethod]
			public void AddUser_Should_Not_Add_User_When_Command_Is_Invalid()
			{
				AddUserCommand command = GetAddCommand();
				command.Valid = false;

				this.Sut.AddUser(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void AddUser_Should_Not_Add_User_When_Email_Has_Invalid_Length()
			{
				string email = "a".PadLeft(256, 'a') + "@.abc.comx";

				AddUserCommand command = GetAddCommand(null, null, null, null, email);

				this.Sut.AddUser(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void AddUser_Should_Not_Add_User_When_FirstName_Has_Invalid_Length()
			{
				string firstName = "a".PadLeft(101, 'a');

				AddUserCommand command = GetAddCommand(null, null, firstName);

				this.Sut.AddUser(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void AddUser_Should_Not_Add_User_When_LastName_Has_Invalid_Length()
			{
				string lastName = "a".PadLeft(101, 'a');

				AddUserCommand command = GetAddCommand(null, null, null, lastName);

				this.Sut.AddUser(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void AddUser_Should_Not_Add_User_When_No_Email()
			{
				string email = string.Empty;

				AddUserCommand command = GetAddCommand(null, null, null, null, email);

				this.Sut.AddUser(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void AddUser_Should_Not_Add_User_When_No_FirstName()
			{
				string firstName = string.Empty;

				AddUserCommand command = GetAddCommand(null, null, firstName);

				this.Sut.AddUser(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void AddUser_Should_Not_Add_User_When_No_LastName()
			{
				string lastName = string.Empty;

				AddUserCommand command = GetAddCommand(null, null, null, lastName);

				this.Sut.AddUser(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void AddUser_Should_Throws_Exception_When_Command_Null()
			{
				AddUserCommand command = null;

				var actual = this.Sut.AddUser(command);
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

		//		EditUserCommand command = new EditUserCommand(id, name, userId);

		//		this.Sut.EditUser(command);

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

		//		EditUserCommand command = new EditUserCommand(id, name, userId);
		//		command.Valid = false;

		//		this.Sut.EditUser(command);

		//		var calls = this.CommandDispatch.ReceivedCalls();

		//		Assert.AreEqual(0, calls.Count());
		//	}

		//	[TestMethod]
		//	public void EditUser_Should_Not_Edit_User_When_Name_Has_Invalid_Length()
		//	{
		//		string id = "id1";
		//		string name = "a".PadLeft(101, 'a');
		//		string userId = "tester";

		//		EditUserCommand command = new EditUserCommand(id, name, userId);

		//		this.Sut.EditUser(command);

		//		var calls = this.CommandDispatch.ReceivedCalls();

		//		Assert.AreEqual(0, calls.Count());
		//	}

		//	[TestMethod]
		//	public void EditUser_Should_Not_Edit_User_When_No_Name()
		//	{
		//		string id = "id1";
		//		string name = "";
		//		string userId = "tester";

		//		EditUserCommand command = new EditUserCommand(id, name, userId);

		//		this.Sut.EditUser(command);

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

		//		EditUserCommand command = new EditUserCommand(id, name, userId, ticket);

		//		this.Sut.EditUser(command);

		//		var calls = this.CommandDispatch.ReceivedCalls();

		//		Assert.AreEqual(0, calls.Count());
		//	}

		//	[TestMethod]
		//	[ExpectedException(typeof(ArgumentNullException))]
		//	public void EditUser_Should_Throws_Exception_When_Command_Null()
		//	{
		//		EditUserCommand command = null;

		//		var actual = this.Sut.EditUser(command);
		//	}

		//	[TestInitialize]
		//	public void SetupTest()
		//	{
		//		this.Initialize();
		//	}
		//}

		//[TestClass]
		//public class GetUsersTest : UserModelTestBase
		//{
		//	[TestMethod]
		//	public void GetUsers_Should_Get_Users()
		//	{
		//		GetUsersQuery query = this.SetQueryDispatcher();

		//		var actual = this.Sut.GetUsers(query);

		//		Assert.AreEqual(3, actual.Users.Count);
		//	}

		//	[TestMethod]
		//	[ExpectedException(typeof(ArgumentNullException))]
		//	public void GetUsers_Should_Throws_Exception_When_Query_Null()
		//	{
		//		GetUsersQuery query = null;

		//		this.Sut.GetUsers(query);
		//	}

		//	[TestInitialize]
		//	public void SetupTest()
		//	{
		//		this.Initialize();
		//	}

		//	private ICollection<User> GetUsers()
		//	{
		//		ICollection<User> users = new List<User>();

		//		User user = new User("1", "User1", "user1");
		//		users.Add(user);

		//		user = new User("2", "User2", "user2");
		//		users.Add(user);

		//		user = new User("3", "User3", "user3");
		//		users.Add(user);

		//		return users;
		//	}

		//	private GetUsersQuery SetQueryDispatcher()
		//	{
		//		GetUsersQuery query = new GetUsersQuery(0, 1, "Name", SortDirection.Ascending);

		//		ICollection<User> users = GetUsers();
		//		GetUsersQueryResult results = new GetUsersQueryResult(users);

		//		this.QueryDispatch.Dispatch<GetUsersQuery, GetUsersQueryResult, User>(query).ReturnsForAnyArgs(results);
		//		return query;
		//	}
		//}
		[TestClass]
		public class SetUserAddVmTest : UserModelTestBase
		{
			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}

			[TestMethod]
			public void SetUserAddVm_Should_Set_Vm()
			{
				AddUserCommand command = GetAddCommand();
				UserAddVm vm = new UserAddVm();
				command.Valid = false;

				this.Sut.SetUserAddVm(command, vm);

				Assert.AreEqual(MessagesModel.FormError, vm.Message);
			}

			[TestMethod]
			public void SetUserAddVm_Should_Set_Vm_When_Email_Invalid()
			{
				AddUserCommand command = GetAddCommand();
				UserAddVm vm = new UserAddVm();
				command.Valid = false;
				string expectedInvalid = "I'm broken";
				command.InvalidEmail = expectedInvalid;

				this.Sut.SetUserAddVm(command, vm);

				Assert.AreEqual(MessagesModel.ItemMessage + expectedInvalid, vm.EmailMessage.Message);
				Assert.AreEqual(MessagesModel.ItemError, vm.EmailMessage.Error);
				Assert.AreEqual(MessagesModel.ItemGroupError, vm.EmailMessage.GroupError);
			}

			[TestMethod]
			public void SetUserAddVm_Should_Set_Vm_When_FirstName_Invalid()
			{
				AddUserCommand command = GetAddCommand();
				UserAddVm vm = new UserAddVm();
				command.Valid = false;
				string expectedInvalid = "I'm broken";
				command.InvalidFirstName = expectedInvalid;

				this.Sut.SetUserAddVm(command, vm);

				Assert.AreEqual(MessagesModel.ItemMessage + expectedInvalid, vm.FirstNameMessage.Message);
				Assert.AreEqual(MessagesModel.ItemError, vm.FirstNameMessage.Error);
				Assert.AreEqual(MessagesModel.ItemGroupError, vm.FirstNameMessage.GroupError);
			}

			[TestMethod]
			public void SetUserAddVm_Should_Set_Vm_When_LastName_Invalid()
			{
				AddUserCommand command = GetAddCommand();
				UserAddVm vm = new UserAddVm();
				command.Valid = false;
				string expectedInvalid = "I'm broken";
				command.InvalidLastName = expectedInvalid;

				this.Sut.SetUserAddVm(command, vm);

				Assert.AreEqual(MessagesModel.ItemMessage + expectedInvalid, vm.LastNameMessage.Message);
				Assert.AreEqual(MessagesModel.ItemError, vm.LastNameMessage.Error);
				Assert.AreEqual(MessagesModel.ItemGroupError, vm.LastNameMessage.GroupError);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void SetUserAddVm_Should_Throw_Exception_When_Command_Is_Null()
			{
				AddUserCommand command = null;
				UserAddVm vm = new UserAddVm();
				this.Sut.SetUserAddVm(command, vm);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void SetUserAddVm_Should_Throw_Exception_When_Vm_Is_Null()
			{
				AddUserCommand command = GetAddCommand();
				UserAddVm vm = null;
				this.Sut.SetUserAddVm(command, vm);
			}
		}
	}

	public class UserModelTestBase : ModelTestBase
	{
		protected UserModel Sut { get; private set; }

		protected AddUserCommand GetAddCommand(string id = null, DateTime? date = null, string firstName = null, string lastName = null, string email = null, ICollection<string> roles = null, ICollection<string> groups = null, bool? isEnabled = null)
		{
			string defaultId = id ?? "id1";
			DateTime defaultDate = date ?? DateTime.Now;
			string defaultFirstName = firstName ?? "UserFirst";
			string defaultLastName = lastName ?? "UserLast";
			string defaultEmail = email ?? "tester@abc.comx";
			ICollection<string> defaultRoles = roles ?? new List<string>();
			ICollection<string> defaultGroups = groups ?? new List<string>();
			bool defaultEnabled = isEnabled ?? true;

			AddUserCommand command = new AddUserCommand(defaultId, defaultDate, defaultFirstName, defaultLastName, defaultEmail, defaultRoles, defaultGroups, defaultEnabled);

			return command;
		}

		protected void Initialize()
		{
			base.InitializeBase();
			this.Sut = new UserModel(this.Config, this.QueryDispatch, this.CommandDispatch);
		}

		//protected EditUserCommand GetEditCommand(string id = null, DateTime? date = null, string firstName = null, string lastName = null, string email = null, ICollection<string> roles = null, ICollection<string> groups = null, bool? isEnabled = null)
		//{
		//	string defaultId = id ?? "id1";
		//	DateTime defaultDate = date ?? DateTime.Now;
		//	string defaultFirstName = firstName ?? "UserFirst";
		//	string defaultLastName = lastName ?? "UserLast";
		//	string defaultEmail = email ?? "tester@abc.comx";
		//	ICollection<string> defaultRoles = roles ?? new List<string>();
		//	ICollection<string> defaultGroups = groups ?? new List<string>();
		//	bool defaultEnabled = isEnabled ?? true;

		//	EditUserCommand command = new EditUserCommand(defaultId, defaultDate, defaultFirstName, defaultLastName, defaultEmail, defaultRoles, defaultGroups, defaultEnabled);

		//	return command;
		//}
	}
}
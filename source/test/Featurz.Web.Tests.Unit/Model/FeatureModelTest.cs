namespace Featurz.Web.Tests.Unit.Model
{
	using System;
using System.Collections.Generic;
using System.Linq;
using Archer.Core.Command;
using Archer.Core.Entity;
using Archer.Core.Repository;
using Featurz.Application.Command;
using Featurz.Application.Entity;
using Featurz.Application.Exceptions;
using Featurz.Application.Query;
using Featurz.Application.QueryResult;
using Featurz.Web.Model;
using Featurz.Web.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;

	[TestClass]
	public class FeatureModelTest
	{
		[TestClass]
		public class AddFeatureTets : FeatureModelTestBase
		{
			[TestMethod]
			public void Should_Add_Feature()
			{
				string id = "id1";
				string name = "Feature 1";
				string userId = "tester";

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId);

				this.Sut.AddFeature(command);

				var calls = this.CommandDispatch.ReceivedCalls();
				ICall call = calls.First();
				string called = call.GetMethodInfo().Name;
				Assert.AreEqual(1, calls.Count());
				Assert.AreEqual("Dispatch", called);
			}

			[TestMethod]
			public void Should_Not_Add_Feature_When_Command_Is_Invalid()
			{
				string id = "id1";
				string name = "Feature 1";
				string userId = "tester";

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId);
				command.Valid = false;

				this.Sut.AddFeature(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void Should_Not_Add_Feature_When_Name_Has_Invalid_Length()
			{
				string id = "id1";
				string name = "a".PadLeft(101, 'a');
				string userId = "tester";

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId);

				this.Sut.AddFeature(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void Should_Not_Add_Feature_When_No_Name()
			{
				string id = "id1";
				string name = "";
				string userId = "tester";

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId);

				this.Sut.AddFeature(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void Should_Not_Add_Feature_When_Ticket_Has_Invalid_Length()
			{
				string id = "id1";
				string name = "Feature 1";
				string userId = "tester";
				string ticket = "a".PadLeft(101, 'a');

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId, ticket);

				this.Sut.AddFeature(command);

				var calls = this.CommandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void Should_Throws_Exception_When_Command_Null()
			{
				AddFeatureCommand command = null;

				var actual = this.Sut.AddFeature(command);
			}
		}

		[TestClass]
		public class GetFeatureOwnersTest : FeatureModelTestBase
		{
			[TestMethod]
			public void Should_Can_Get_Feature_Owners()
			{
				GetFeatureOwnersQuery query = SetQueryDispatcher();

				var actual = this.Sut.GetFeatureOwners(query);

				Assert.AreEqual(3, actual.Count);
			}

			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void Should_Throws_Exception_When_Query_Null()
			{
				GetFeatureOwnersQuery query = null;

				var actual = this.Sut.GetFeatureOwners(query);
			}

			private static ICollection<User> GetUsers()
			{
				ICollection<User> users = new List<User>();
				User user = new User("1", "tester1", "Tester", "Master1", new List<string> { "admin", "owner", "user" });
				users.Add(user);
				user = new User("2", "tester2", "Tester2", "Master2", new List<string> { "owner", "user" });
				users.Add(user);
				user = new User("3", "tester3", "Tester3", "Master3", new List<string> { "user" });
				users.Add(user);
				return users;
			}

			private GetFeatureOwnersQuery SetQueryDispatcher()
			{
				GetFeatureOwnersQuery query = new GetFeatureOwnersQuery(0, 1, "Name", SortDirection.Ascending);

				ICollection<User> users = GetUsers();
				GetFeatureOwnersQueryResult results = new GetFeatureOwnersQueryResult(users);

				this.QueryDispatch.Dispatch<GetFeatureOwnersQuery, GetFeatureOwnersQueryResult, User>(query).ReturnsForAnyArgs(results);
				return query;
			}
		}

		[TestClass]
		public class GetFeaturesTest : FeatureModelTestBase
		{
			[TestMethod]
			public void Should_Can_Get_Features()
			{
				GetFeaturesQuery query = this.SetQueryDispatcher();

				var actual = this.Sut.GetFeatures(query);

				Assert.AreEqual(3, actual.Features.Count);
			}

			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void Should_Throws_Exception_When_Query_Null()
			{
				GetFeaturesQuery query = null;

				this.Sut.GetFeatures(query);
			}

			private ICollection<Feature> GetFeatures()
			{
				ICollection<Feature> features = new List<Feature>();

				Feature feature = new Feature("1", "Feature1", "user1");
				features.Add(feature);

				feature = new Feature("2", "Feature2", "user2");
				features.Add(feature);

				feature = new Feature("3", "Feature3", "user3");
				features.Add(feature);

				return features;
			}

			private GetFeaturesQuery SetQueryDispatcher()
			{
				GetFeaturesQuery query = new GetFeaturesQuery(0, 1, "Name", SortDirection.Ascending);

				ICollection<Feature> features = GetFeatures();
				GetFeaturesQueryResult results = new GetFeaturesQueryResult(features);

				this.QueryDispatch.Dispatch<GetFeaturesQuery, GetFeaturesQueryResult, Feature>(query).ReturnsForAnyArgs(results);
				return query;
			}
		}

		[TestClass]
		public class SetFeatureAddVmTest : FeatureModelTestBase
		{
			[TestMethod]
			public void Should_Set_Vm()
			{
				AddFeatureCommand command = new AddFeatureCommand("1", "Feature1", "testuser");
				FeatureAddVm vm = new FeatureAddVm();
				command.Valid = false;
				
				this.Sut.SetFeatureAddVm(command, vm);

				Assert.AreEqual(MessagesModel.FormError, vm.Message);
			}

			[TestMethod]
			public void Should_Set_Vm_When_Name_Invalid()
			{
				AddFeatureCommand command = new AddFeatureCommand("1", "Feature1", "testuser");
				FeatureAddVm vm = new FeatureAddVm();
				command.Valid = false;
				string expectedInvalid = "I'm broken";
				command.InvalidName = expectedInvalid;

				this.Sut.SetFeatureAddVm(command, vm);

				Assert.AreEqual(MessagesModel.ItemMessage + expectedInvalid, vm.NameMessage);
				Assert.AreEqual(MessagesModel.ItemError, vm.NameError);
				Assert.AreEqual(MessagesModel.ItemGroupError, vm.NameGroupError);
			}

			[TestMethod]
			public void Should_Set_Vm_When_Ticket_Invalid()
			{
				AddFeatureCommand command = new AddFeatureCommand("1", "Feature1", "testuser");
				FeatureAddVm vm = new FeatureAddVm();
				command.Valid = false;
				string expectedInvalid = "I'm broken";
				command.InvalidTicket = expectedInvalid;

				this.Sut.SetFeatureAddVm(command, vm);

				Assert.AreEqual(MessagesModel.ItemMessage + expectedInvalid, vm.TicketMessage);
				Assert.AreEqual(MessagesModel.ItemError, vm.TicketError);
				Assert.AreEqual(MessagesModel.ItemGroupError, vm.TicketGroupError);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void Should_Throw_Exception_When_Command_Is_Null()
			{
				AddFeatureCommand command = null;
				FeatureAddVm vm = new FeatureAddVm();
				this.Sut.SetFeatureAddVm(command, vm);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void Should_Throw_Exception_When_Vm_Is_Null()
			{
				AddFeatureCommand command = new AddFeatureCommand("1", "Feature1", "testuser");
				FeatureAddVm vm = null;
				this.Sut.SetFeatureAddVm(command, vm);
			}
			
			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}
		}
	}

	public class FeatureModelTestBase : ModelTestBase
	{
		protected FeatureModel Sut { get; private set; }

		protected void Initialize()
		{
			base.InitializeBase();
			this.Sut = new FeatureModel(this.Config, this.QueryDispatch, this.CommandDispatch);
		}
	}
}
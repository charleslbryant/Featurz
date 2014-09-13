namespace Featurz.Web.Tests.Unit
{
	using System;
	using System.Linq;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Query;
	using Featurz.Application.Command;
	using Featurz.Web.Model;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;
	using NSubstitute.Core;

	[TestClass]
	public class FeatureModelTest
	{
		[TestClass]
		public class AddFeatureTets
		{
			private ICommandDispatcher commandDispatch;
			private IConfiguration config;
			private IQueryDispatcher queryDispatch;
			private FeatureModel sut;

			[TestMethod]
			public void Can_Add_Feature()
			{
				string id = "id1";
				string name = "Feature 1";
				string userId = "tester";

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId);

				sut.AddFeature(command);

				var calls = commandDispatch.ReceivedCalls();
				ICall call = calls.First();
				string called = call.GetMethodInfo().Name;
				Assert.AreEqual("Dispatch", called);
			}

			[TestMethod]
			public void Does_Not_Add_Feature_With_Invalid_Command()
			{
				string id = "id1";
				string name = "Feature 1";
				string userId = "tester";

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId);
				command.Valid = false;

				sut.AddFeature(command);

				var calls = commandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void Does_Not_Add_Feature_With_Name_With_Invalid_Length()
			{
				string id = "id1";
				string name = "a".PadLeft(101, 'a');
				string userId = "tester";

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId);

				sut.AddFeature(command);

				var calls = commandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void Does_Not_Add_Feature_With_No_Name()
			{
				string id = "id1";
				string name = "";
				string userId = "tester";

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId);

				sut.AddFeature(command);

				var calls = commandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestMethod]
			public void Does_Not_Add_Feature_With_Ticket_With_Invalid_Length()
			{
				string id = "id1";
				string name = "Feature 1";
				string userId = "tester";
				string ticket = "a".PadLeft(101, 'a');

				AddFeatureCommand command = new AddFeatureCommand(id, name, userId, ticket);

				sut.AddFeature(command);

				var calls = commandDispatch.ReceivedCalls();

				Assert.AreEqual(0, calls.Count());
			}

			[TestInitialize]
			public void SetupTest()
			{
				config = Substitute.For<IConfiguration>();
				queryDispatch = Substitute.For<IQueryDispatcher>();
				commandDispatch = Substitute.For<ICommandDispatcher>();
				sut = new FeatureModel(config, queryDispatch, commandDispatch);
			}
		}
	}
}
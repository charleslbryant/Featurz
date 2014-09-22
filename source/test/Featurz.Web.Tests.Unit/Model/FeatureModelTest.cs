namespace Featurz.Web.Tests.Unit.Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Archer.Core.Entity;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.CommandResult.Feature;
	using Featurz.Application.Entity;
	using Featurz.Application.Query.Feature;
	using Featurz.Application.QueryResult.Feature;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.Feature;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;
	using NSubstitute.Core;

	[TestClass]
	public class FeatureModelTest
	{
		//TODO test catching of dispatcher exceptions
		[TestClass]
		public class AddFeatureTest : FeatureModelTestBase
		{
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void AddFeature_Should_Throws_Exception_When_Command_Null()
			{
				FeatureVm vm = null;

				var actual = this.Sut.AddFeature(vm);
			}

			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}
		}

		//TODO test catching of dispatcher exceptions
		[TestClass]
		public class EditFeatureTest : FeatureModelTestBase
		{
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void EditFeature_Should_Throws_Exception_When_Command_Null()
			{
				FeatureVm vm = null;

				var actual = this.Sut.EditFeature(vm);
			}

			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}
		}

		[TestClass]
		public class GetFeatureOwnersTest : FeatureModelTestBase
		{
			[TestMethod]
			public void GetFeatureOwners_Should_Get_Feature_Owners()
			{
				GetFeatureOwnersQuery query = SetQueryDispatcher();

				var actual = this.Sut.GetFeatureOwners(query);

				Assert.AreEqual(3, actual.Count);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void GetFeatureOwners_Should_Throws_Exception_When_Query_Null()
			{
				GetFeatureOwnersQuery query = null;

				var actual = this.Sut.GetFeatureOwners(query);
			}

			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}

			private static ICollection<User> GetUsers()
			{
				ICollection<User> users = new List<User>();
				DateTime date = DateTime.Now;
				User user = new User("1", date, "tester1", "Tester", "Master1", new List<string> { "admin", "owner", "user" }, new List<string> { }, true);
				users.Add(user);
				user = new User("2", date, "tester2", "Tester2", "Master2", new List<string> { "owner", "user" }, new List<string> { }, true);
				users.Add(user);
				user = new User("3", date, "tester3", "Tester3", "Master3", new List<string> { "user" }, new List<string> { }, true);
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
			public void GetFeatures_Should_Get_Features()
			{
				GetFeaturesQuery query = this.SetQueryDispatcher();

				var actual = this.Sut.GetFeatures(query);

				Assert.AreEqual(3, actual.Features.Count);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void GetFeatures_Should_Throws_Exception_When_Query_Null()
			{
				GetFeaturesQuery query = null;

				this.Sut.GetFeatures(query);
			}

			[TestInitialize]
			public void SetupTest()
			{
				this.Initialize();
			}

			private ICollection<Feature> GetFeatures()
			{
				ICollection<Feature> features = new List<Feature>();
				DateTime date = DateTime.Now;
				Feature feature = new Feature("1", date, "Feature1", "user1");
				features.Add(feature);

				feature = new Feature("2", date, "Feature2", "user2");
				features.Add(feature);

				feature = new Feature("3", date, "Feature3", "user3");
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
	}

	public class FeatureModelTestBase : ModelTestBase
	{
		protected FeatureModel Sut { get; private set; }

		protected FeatureVm GetFeatureVm(string id = null, DateTime? date = null, string name = null, string userId = null, string ticket = null)
		{
			string defaultId = id ?? "id1";
			DateTime defaultDate = date ?? DateTime.Now;
			string defaultName = name ?? "Feature 1";
			string defaultUserId = userId ?? "tester";
			string defaultTicket = ticket ?? "";

			FeatureVm vm = new FeatureVm();
			vm.Id = defaultId;
			vm.DateAdded = defaultDate;
			vm.Name = defaultName;
			vm.UserId = defaultUserId;
			vm.Ticket = defaultTicket;

			return vm;
		}

		protected void Initialize()
		{
			base.InitializeBase();
			this.Sut = new FeatureModel(this.Config, this.QueryDispatch, this.CommandDispatch);
		}
	}
}
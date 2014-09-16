namespace Featurz.Web.Tests.Unit.Model
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Configuration;
	using Featurz.Application.Entity;
	using Featurz.Application.QueryResult;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;

	[TestClass]
	public class FeatureModelHelperTest
	{
		[TestClass]
		public class SetActiveTest
		{
			[TestMethod]
			public void SetActive_Should_Set_Active_When_Feature_Is_Active()
			{
				FeatureListItemVm feature = new FeatureListItemVm();
				Feature result = new Feature("1", "Feature1", "testuser", "1", true);

				FeatureListItemVm actual = FeatureModelHelper.SetActive(feature, result);

				Assert.AreEqual("Active", actual.Active);
				Assert.AreEqual("success", actual.ActiveClass);
			}

			[TestMethod]
			public void SetActive_Should_Set_Inactive_When_Feature_Is_Inactive()
			{
				FeatureListItemVm feature = new FeatureListItemVm();
				Feature result = new Feature("1", "Feature1", "testuser", "1", false);

				FeatureListItemVm actual = FeatureModelHelper.SetActive(feature, result);

				Assert.AreEqual("Inactive", actual.Active);
				Assert.AreEqual("danger", actual.ActiveClass);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void SetActive_Should_Throw_Exception_When_Feature_Is_Null()
			{
				FeatureListItemVm feature = null;
				Feature result = new Feature("1", "Feature1", "testuser", "1", false);

				FeatureListItemVm actual = FeatureModelHelper.SetActive(feature, result);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void SetActive_Should_Throw_Exception_When_Result_Is_Null()
			{
				FeatureListItemVm feature = new FeatureListItemVm();
				Feature result = null;

				FeatureListItemVm actual = FeatureModelHelper.SetActive(feature, result);
			}
		}

		[TestClass]
		public class ToFeatureListVmTest
		{
			[TestMethod]
			public void ToFeatureListVm_Should_Return_FeatureListVm_When_Items_Found()
			{
				ICollection<Feature> features = new List<Feature>();
				Feature feature = new Feature("1", "Feature1", "testuser");
				features.Add(feature);
				feature = new Feature("2", "Feature2", "testuser");
				features.Add(feature);
				feature = new Feature("3", "Feature3", "testuser");
				features.Add(feature);
				GetFeaturesQueryResult results = new GetFeaturesQueryResult(features);

				IConfiguration config = GetConfig();
				
				FeatureListVm actual = FeatureModelHelper.ToFeatureListVm(results, config);

				Assert.AreEqual(3, actual.Features.Count);
			}

			private static IConfiguration GetConfig()
			{
				IConfiguration config = Substitute.For<IConfiguration>();
				config.Get<string>("featurz.ticketsystemurl").Returns("someUrl.com");
				return config;
			}

			[TestMethod]
			public void ToFeatureListVm_Should_Return_FeatureListVm_When_No_Items_Found()
			{
				ICollection<Feature> features = new List<Feature>();
				GetFeaturesQueryResult results = new GetFeaturesQueryResult(features);

				IConfiguration config = GetConfig();

				FeatureListVm actual = FeatureModelHelper.ToFeatureListVm(results, config);

				Assert.AreEqual(MessagesModel.NoItemsFound, actual.Message);
				Assert.AreEqual(MessagesModel.MessageStyles.Info, actual.MessageStyle);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ToFeatureListVm_Should_Throw_Exception_When_Results_Is_Null()
			{
				GetFeaturesQueryResult results = null;

				IConfiguration config = GetConfig();

				FeatureListVm actual = FeatureModelHelper.ToFeatureListVm(results, config);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ToFeatureListVm_Should_Throw_Exception_When_Config_Is_Null()
			{
				ICollection<Feature> features = new List<Feature>();
				GetFeaturesQueryResult results = new GetFeaturesQueryResult(features);

				IConfiguration config = null;

				FeatureListVm actual = FeatureModelHelper.ToFeatureListVm(results, config);
			}
		}

		[TestClass]
		public class ToFeatureOwnerVmTest
		{
			[TestMethod]
			public void ToFeatureOwnerVm_Should_Return_FeatureOwnerVm()
			{
				User result = new User("1", "email@test.comx", "MyFirstName", "MyLastName", null);

				FeatureOwnerVm actual = FeatureModelHelper.ToFeatureOwnerVm(result);

				Assert.AreEqual("MyFirstName MyLastName", actual.Name);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ToFeatureOwnerVm_Should_Throw_Exception_When_Result_Is_Null()
			{
				User result = null;

				FeatureOwnerVm actual = FeatureModelHelper.ToFeatureOwnerVm(result);
			}
		}

		[TestClass]
		public class ToFeatureEditVmTest
		{
			[TestMethod]
			public void ToFeatureEditVm_Should_Return_FeatureEditVm()
			{
				string id = "1";
				string name = "Test Feature";
				string userId = "testuser";
				string ticket = "T1";
				bool active = true;
				bool enabled = true;
				int strategyId = 0;

				GetFeatureQueryResult result = new GetFeatureQueryResult(id, name, userId, ticket, active, enabled, strategyId);

				FeatureEditVm actual = FeatureModelHelper.ToFeatureEditVm(result);

				Assert.AreEqual(id, actual.Id);
				Assert.AreEqual(name, actual.Name);
				Assert.AreEqual(userId, actual.UserId);
				Assert.AreEqual(ticket, actual.Ticket);
				Assert.AreEqual(active, actual.IsActive);
				Assert.AreEqual(enabled, actual.IsEnabled);
				Assert.AreEqual(strategyId, actual.StrategyId);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ToFeatureEditVm_Should_Throw_Exception_When_Result_Is_Null()
			{
				GetFeatureQueryResult result = null;

				FeatureEditVm actual = FeatureModelHelper.ToFeatureEditVm(result);
			}
		}
	}
}

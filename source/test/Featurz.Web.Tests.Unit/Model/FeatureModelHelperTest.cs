namespace Featurz.Web.Tests.Unit.Model
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Configuration;
	using Featurz.Application.CommandResult.Feature;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;
	using Featurz.Application.QueryResult.Feature;
	using Featurz.Web.Model;
	using Featurz.Web.ViewModel.Feature;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;

	[TestClass]
	public class FeatureModelHelperTest
	{
		[TestClass]
		public class CommandResultToFeatureVmTest : FeatureModelHelperTestBase
		{
			[TestMethod]
			public void CommandResultToFeatureVm_Should_Return_FeatureVm()
			{
				string id = "good";
				string idMessage = MessagesModel.ItemMessage + id;
				string name = "bad";
				string nameMessage = MessagesModel.ItemMessage + name;
				string ticket = "ugly";
				string ticketMessage = MessagesModel.ItemMessage + ticket;

				FeatureCommandResult result = new FeatureCommandResult();
				result.InvalidId = id;
				result.InvalidName = name;
				result.InvalidTicket = ticket;

				FeatureVm actual = FeatureModelHelper.CommandResultToFeatureVm(result);

				Assert.AreEqual(idMessage, actual.IdMessage.Message);
				Assert.AreEqual(MessagesModel.ItemError, actual.IdMessage.Error);
				Assert.AreEqual(MessagesModel.ItemGroupError, actual.IdMessage.GroupError);
				Assert.AreEqual(nameMessage, actual.NameMessage.Message);
				Assert.AreEqual(MessagesModel.ItemError, actual.NameMessage.Error);
				Assert.AreEqual(MessagesModel.ItemGroupError, actual.NameMessage.GroupError);
				Assert.AreEqual(ticketMessage, actual.TicketMessage.Message);
				Assert.AreEqual(MessagesModel.ItemError, actual.TicketMessage.Error);
				Assert.AreEqual(MessagesModel.ItemGroupError, actual.TicketMessage.GroupError);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void QueryResultToFeatureEditVm_Should_Throw_Exception_When_Result_Is_Null()
			{
				GetFeatureQueryResult result = null;

				FeatureVm actual = FeatureModelHelper.QueryResultToFeatureVm(result);
			}
		}

		[TestClass]
		public class QueryResultToFeatureVmTest : FeatureModelHelperTestBase
		{
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void QueryResultToFeatureEditVm_Should_Throw_Exception_When_Result_Is_Null()
			{
				GetFeatureQueryResult result = null;

				FeatureVm actual = FeatureModelHelper.QueryResultToFeatureVm(result);
			}

			[TestMethod]
			public void QueryResultToFeatureVm_Should_Return_FeatureVm()
			{
				string id = "1";
				string name = "Test Feature";
				string userId = "testuser";
				string ticket = "T1";
				bool active = true;
				bool enabled = true;
				int strategyId = 0;

				GetFeatureQueryResult result = new GetFeatureQueryResult(id, name, userId, ticket, active, enabled, strategyId);

				FeatureVm actual = FeatureModelHelper.QueryResultToFeatureVm(result);

				Assert.AreEqual(id, actual.Id);
				Assert.AreEqual(name, actual.Name);
				Assert.AreEqual(userId, actual.UserId);
				Assert.AreEqual(ticket, actual.Ticket);
				Assert.AreEqual(active, actual.IsActive);
				Assert.AreEqual(enabled, actual.IsEnabled);
				Assert.AreEqual(strategyId, actual.StrategyId);
			}
		}

		[TestClass]
		public class ResultToFeatureListVmTest : FeatureModelHelperTestBase
		{
			[TestMethod]
			public void ResultToFeatureListVm_Should_Return_FeatureListVm_When_Items_Found()
			{
				DateTime date = DateTime.Now;
				ICollection<Feature> features = new List<Feature>();
				Feature feature = new Feature("1", date, "Feature1", "testuser");
				features.Add(feature);
				feature = new Feature("2", date, "Feature2", "testuser");
				features.Add(feature);
				feature = new Feature("3", date, "Feature3", "testuser");
				features.Add(feature);
				GetFeaturesQueryResult results = new GetFeaturesQueryResult(features);

				IConfiguration config = GetConfig();

				FeatureListVm actual = FeatureModelHelper.ResultToFeatureListVm(results, config);

				Assert.AreEqual(3, actual.Features.Count);
			}

			[TestMethod]
			public void ResultToFeatureListVm_Should_Return_FeatureListVm_When_No_Items_Found()
			{
				ICollection<Feature> features = new List<Feature>();
				GetFeaturesQueryResult results = new GetFeaturesQueryResult(features);

				IConfiguration config = GetConfig();

				FeatureListVm actual = FeatureModelHelper.ResultToFeatureListVm(results, config);

				Assert.AreEqual(MessagesModel.NoItemsFound, actual.Message);
				Assert.AreEqual(MessagesModel.MessageStyles.Info, actual.MessageStyle);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ResultToFeatureListVm_Should_Throw_Exception_When_Config_Is_Null()
			{
				ICollection<Feature> features = new List<Feature>();
				GetFeaturesQueryResult results = new GetFeaturesQueryResult(features);

				IConfiguration config = null;

				FeatureListVm actual = FeatureModelHelper.ResultToFeatureListVm(results, config);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ResultToFeatureListVm_Should_Throw_Exception_When_Results_Is_Null()
			{
				GetFeaturesQueryResult results = null;

				IConfiguration config = GetConfig();

				FeatureListVm actual = FeatureModelHelper.ResultToFeatureListVm(results, config);
			}

			private static IConfiguration GetConfig()
			{
				IConfiguration config = Substitute.For<IConfiguration>();
				config.Get<string>("featurz.ticketsystemurl").Returns("someUrl.com");
				return config;
			}
		}

		[TestClass]
		public class SetActiveTest : FeatureModelHelperTestBase
		{
			[TestMethod]
			public void SetActive_Should_Set_Active_When_Feature_Is_Active()
			{
				FeatureListItemVm feature = new FeatureListItemVm();
				Feature result = this.GetFeature();

				FeatureListItemVm actual = FeatureModelHelper.SetActive(feature, result);

				Assert.AreEqual("Active", actual.Active);
				Assert.AreEqual("success", actual.ActiveClass);
			}

			[TestMethod]
			public void SetActive_Should_Set_Inactive_When_Feature_Is_Inactive()
			{
				FeatureListItemVm feature = new FeatureListItemVm();
				Feature result = this.GetFeature(false);

				FeatureListItemVm actual = FeatureModelHelper.SetActive(feature, result);

				Assert.AreEqual("Inactive", actual.Active);
				Assert.AreEqual("danger", actual.ActiveClass);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void SetActive_Should_Throw_Exception_When_Feature_Is_Null()
			{
				FeatureListItemVm feature = null;
				Feature result = this.GetFeature();

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
		public class SetEnabledTest : FeatureModelHelperTestBase
		{
			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void SetActive_Should_Throw_Exception_When_Feature_Is_Null()
			{
				FeatureListItemVm feature = null;
				Feature result = this.GetFeature();

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

			[TestMethod]
			public void SetEnabled_Should_Set_Disabled_When_Feature_Is_Disabled()
			{
				FeatureListItemVm feature = new FeatureListItemVm();
				Feature result = this.GetFeature(true, false);

				FeatureListItemVm actual = FeatureModelHelper.SetEnabled(feature, result);

				Assert.AreEqual("Disabled", actual.Enabled);
				Assert.AreEqual("danger", actual.EnabledClass);
			}

			[TestMethod]
			public void SetEnabled_Should_Set_Enabled_When_Feature_Is_Enabled()
			{
				FeatureListItemVm feature = new FeatureListItemVm();
				Feature result = this.GetFeature();

				FeatureListItemVm actual = FeatureModelHelper.SetEnabled(feature, result);

				Assert.AreEqual("Enabled", actual.Enabled);
				Assert.AreEqual("success", actual.EnabledClass);
			}
		}

		[TestClass]
		public class ToFeatureOwnerVmTest : FeatureModelHelperTestBase
		{
			[TestMethod]
			public void ToFeatureOwnerVm_Should_Return_FeatureOwnerVm()
			{
				User result = new User("1", DateTime.Now, "email@test.comx", "MyFirstName", "MyLastName", null, null, true);

				FeatureOwnerVm actual = FeatureModelHelper.ResultToFeatureOwnerVm(result);

				Assert.AreEqual("MyFirstName MyLastName", actual.Name);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ToFeatureOwnerVm_Should_Throw_Exception_When_Result_Is_Null()
			{
				User result = null;

				FeatureOwnerVm actual = FeatureModelHelper.ResultToFeatureOwnerVm(result);
			}
		}
	}

	public class FeatureModelHelperTestBase
	{
		protected Feature GetFeature(bool active = true, bool enabled = true)
		{
			Feature feature = new Feature("1", DateTime.Now, "Feature1", "testuser", "1", active, enabled);
			return feature;
		}
	}
}
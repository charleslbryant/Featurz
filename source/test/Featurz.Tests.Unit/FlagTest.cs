namespace Featurz.Application.Tests.Unit
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Repository;
	using Featurz.Application.Entity;
	using Featurz.Application.QueryHandler;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;

	[TestClass]
	public class FlagTest
	{
		[TestClass]
		public class IsActiveTest
		{
			[TestMethod]
			public void IsActive_Should_Return_Inactive_When_Feature_Is_Null()
			{
				var featureRepo = Substitute.For<IReadRepository<Feature>>();
				var query = new IsFeatureActiveQueryHandler();
				query.ReadRepository = featureRepo;
				string name = "test";

				IList<Feature> features = new List<Feature>();
				Feature feature = null;
				features.Add(feature);

				featureRepo.Where(x => x.Name == Arg.Any<string>()).ReturnsForAnyArgs(features);

				bool actual = Flag.IsActive(name, query);

				Assert.IsFalse(actual);
			}

			[TestMethod]
			public void IsActive_Should_Return_True_When_Feature_Is_Active()
			{
				var featureRepo = Substitute.For<IReadRepository<Feature>>();
				var query = new IsFeatureActiveQueryHandler();
				query.ReadRepository = featureRepo;
				string featureId = "1000";
				string name = "test";

				IList<Feature> features = new List<Feature>();
				Feature feature = new Feature(featureId, name, "1", "F1", true);
				features.Add(feature);

				featureRepo.Where(x => x.Name == Arg.Any<string>()).ReturnsForAnyArgs(features);

				bool actual = Flag.IsActive(name, query);

				Assert.IsTrue(actual);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentException))]
			public void IsActive_Should_Throw_Exception_When_FeatureId_Is_White_Space()
			{
				string name = string.Empty;

				bool actual = Flag.IsActive(name);
			}
		}
	}
}
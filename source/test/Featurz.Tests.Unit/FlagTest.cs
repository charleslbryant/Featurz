namespace Featurz.Application.Tests.Unit
{
	using System;
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
			public void IsActive_Returns_True()
			{
				var featureRepo = Substitute.For<IReadRepository<Feature>>();
				var query = new IsFeatureActiveQueryHandler();
				query.ReadRepository = featureRepo;
				Feature feature = new Feature("1000", "test", "1", "F1", true);

				string featureId = "1000";

				featureRepo.GetById(featureId).Returns<Feature>(feature);

				bool actual = Flag.IsActive(featureId, query);

				Assert.IsTrue(actual);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentException))]
			public void IsActive_When_FeatureId_Is_White_Space_Throw_Exception()
			{
				string featureId = "";

				bool actual = Flag.IsActive(featureId);
			}
		}
	}
}
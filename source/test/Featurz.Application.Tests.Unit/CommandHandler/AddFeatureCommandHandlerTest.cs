namespace Featurz.Application.Tests.Unit.CommandHandler
{
	using System;
	using Archer.Core.Repository;
	using Featurz.Application.Entity;
	using Featurz.Application.Command;
	using Featurz.Application.CommandHandler;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;
	using System.Collections.Generic;
	using Featurz.Application.Exceptions;
	using Archer.Core.Exceptions;

	[TestClass]
	public class AddFeatureCommandHandlerTest
	{
		[TestClass]
		public class ExecuteTest
		{
			//TODO: Test duplicate key exception.
			[TestMethod]
			[ExpectedException(typeof(DuplicateFeatureException))]
			public void AddFeatureCommandHandler_Should_Throws_Exception_When_Adding_Feature_With_Duplicate_Name()
			{
				AddFeatureCommandHandler sut = new AddFeatureCommandHandler();
				IReadRepository<Feature> read = Substitute.For<IReadRepository<Feature>>();
				sut.ReadRepository = read;

				string id = "id1";
				string name = "Feature 1";
				string user = "tester";

				IList<Feature> features = new List<Feature>();
				Feature feature = new Feature(id, name, user, name, true);
				features.Add(feature);

				read.Where(x => x.Name == Arg.Any<string>()).ReturnsForAnyArgs(features);
				
				AddFeatureCommand command = new AddFeatureCommand(id, name, user);

				sut.Execute(command);
			}
		}
	}
}

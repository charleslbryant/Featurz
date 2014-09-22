namespace Featurz.Application.Tests.Unit.CommandHandler.Feature
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Archer.Core.Repository;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.CommandHandler.Feature;
	using Featurz.Application.CommandResult.Feature;
	using Featurz.Application.Entity;
	using Featurz.Application.Exceptions;
	using Featurz.Application.Message;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;

	[TestClass]
	public class EditFeatureCommandHandlerTest
	{
		[TestClass]
		public class ExecuteTest
		{
			[TestMethod]
			public void Execute_Should_Not_Edit_Invalid_Feature()
			{
				EditFeatureCommandHandler sut = GetCommandHandler();

				EditFeatureCommand command = FeatureCommandHandlerTestHelper.GetEditCommand("Feature 1", "a".PadLeft(101, 'a'));

				string expectedInvalid = string.Format(MessagesModel.MaxLength, "100");

				FeatureCommandResult result = sut.Execute(command);

				var calls = sut.WriteRepository.ReceivedCalls().Count();

				Assert.AreEqual(0, calls);
			}

			private EditFeatureCommandHandler GetCommandHandler()
			{
				EditFeatureCommandHandler sut = new EditFeatureCommandHandler();
				IReadRepository<Feature> read = Substitute.For<IReadRepository<Feature>>();
				sut.ReadRepository = read;
				IWriteRepository<Feature> write = Substitute.For<IWriteRepository<Feature>>();
				sut.WriteRepository = write;
				return sut;
			}
		}
	}
}
namespace Featurz.Application.Tests.Unit.CommandHandler.Feature
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Repository;
	using Featurz.Application.Command.Feature;
	using Featurz.Application.CommandHandler.Feature;
	using Featurz.Application.CommandResult.Feature;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;

	[TestClass]
	public class FeatureCommandHandlerHelperTest
	{
		[TestClass]
		public class ValidateTest
		{
			private IReadRepository<Feature> read;
			private IWriteRepository<Feature> write;

			[TestInitialize]
			public void TestSetup()
			{
				read = Substitute.For<IReadRepository<Feature>>();
				write = Substitute.For<IWriteRepository<Feature>>();
			}

			[TestMethod]
			[ExpectedException(typeof(Exception), "WriteRespository can not be a null value.")]
			public void Validate_Should_Throw_Exception_When_WriteRepository_Is_Null()
			{
				FeatureCommand command = FeatureCommandHandlerTestHelper.GetCommand();

				this.write = null;

				FeatureCommandHandlerHelper.Validate(command, this.write, this.read);
			}

			[TestMethod]
			[ExpectedException(typeof(Exception), "ReadRespository can not be a null value.")]
			public void Validate_Should_Throw_Exception_When_ReadRepository_Is_Null()
			{
				FeatureCommand command = FeatureCommandHandlerTestHelper.GetCommand();

				this.read = null;

				FeatureCommandHandlerHelper.Validate(command, this.write, this.read);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void Validate_Should_Throw_Exception_When_Command_Is_Null()
			{
				FeatureCommand command = null;

				FeatureCommandHandlerHelper.Validate(command, this.write, this.read);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_Feature_With_No_Id()
			{
				FeatureCommand command = FeatureCommandHandlerTestHelper.GetCommand(null, null, "");

				string expectedInvalid = MessagesModel.Required;

				FeatureCommandResult result = FeatureCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidName);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_Feature_With_No_Name()
			{
				FeatureCommand command = FeatureCommandHandlerTestHelper.GetCommand("");

				string expectedInvalid = MessagesModel.Required;

				FeatureCommandResult result = FeatureCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidName);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_Feature_With_Invalid_Name_Length()
			{
				FeatureCommand command = FeatureCommandHandlerTestHelper.GetCommand("a".PadLeft(101, 'a'), null, null);

				string expectedInvalid = string.Format(MessagesModel.MaxLength, "100");

				FeatureCommandResult result = FeatureCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidName);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_Feature_With_Duplicate_Name()
			{
				FeatureCommand command = FeatureCommandHandlerTestHelper.GetCommand();

				IList<Feature> features = Substitute.For<IList<Feature>>();
				features.Count.Returns(1);

				read.Where(x => x.Name == "Feature 1").ReturnsForAnyArgs(features);

				string expectedInvalid = string.Format("A feature already exists with the name {0}", command.Name);

				FeatureCommandResult result = FeatureCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidName);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_Feature_With_Invalid_Ticket_Length()
			{
				FeatureCommand command = FeatureCommandHandlerTestHelper.GetCommand("Feature 1", "a".PadLeft(101, 'a'));

				string expectedInvalid = string.Format(MessagesModel.MaxLength, "100");

				FeatureCommandResult result = FeatureCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidTicket);
			}
		}
	}
}
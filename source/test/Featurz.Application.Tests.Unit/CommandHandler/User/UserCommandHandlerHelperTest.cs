namespace Featurz.Application.Tests.Unit.CommandHandler.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Repository;
	using Featurz.Application.Command.User;
	using Featurz.Application.CommandHandler.User;
	using Featurz.Application.CommandResult.User;
	using Featurz.Application.Entity;
	using Featurz.Application.Message;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;

	[TestClass]
	public class UserCommandHandlerHelperTest
	{
		[TestClass]
		public class ValidateTest
		{
			private IReadRepository<User> read;
			private IWriteRepository<User> write;

			[TestInitialize]
			public void TestSetup()
			{
				read = Substitute.For<IReadRepository<User>>();
				write = Substitute.For<IWriteRepository<User>>();
			}

			[TestMethod]
			[ExpectedException(typeof(Exception), "WriteRespository can not be a null value.")]
			public void Validate_Should_Throw_Exception_When_WriteRepository_Is_Null()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand();

				this.write = null;

				UserCommandHandlerHelper.Validate(command, this.write, this.read);
			}

			[TestMethod]
			[ExpectedException(typeof(Exception), "ReadRespository can not be a null value.")]
			public void Validate_Should_Throw_Exception_When_ReadRepository_Is_Null()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand();

				this.read = null;

				UserCommandHandlerHelper.Validate(command, this.write, this.read);
			}

			[TestMethod]
			[ExpectedException(typeof(ArgumentNullException))]
			public void Validate_Should_Throw_Exception_When_Command_Is_Null()
			{
				UserCommand command = null;

				UserCommandHandlerHelper.Validate(command, this.write, this.read);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_Duplicate_Id()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand();

				User user = new User(command.Id, command.DateAdded, command.Email, command.FirstName, command.LastName, command.Roles, command.Groups, command.IsEnabled);

				read.GetById("id1").Returns(user);

				string expectedInvalid = string.Format("A user already exists with the username {0}", command.Id);

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidId);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_Empty_Id()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand("");

				string expectedInvalid = MessagesModel.Required;

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidId);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_Invalid_Id_Length()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand("a".PadLeft(51, 'a'));

				string expectedInvalid = string.Format(MessagesModel.MaxLength, "50");

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidId);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_No_FirstName()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand(null, "");

				string expectedInvalid = MessagesModel.Required;

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidFirstName);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_Invalid_FirstName_Length()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand(null, "a".PadLeft(101, 'a'));

				string expectedInvalid = string.Format(MessagesModel.MaxLength, "100");

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidFirstName);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_No_LastName()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand(null, null, "");

				string expectedInvalid = MessagesModel.Required;

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidLastName);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_Invalid_LastName_Length()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand(null, null, "a".PadLeft(101, 'a'));

				string expectedInvalid = string.Format(MessagesModel.MaxLength, "100");

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidLastName);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_Duplicate_Email()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand();

				IList<User> users = Substitute.For<IList<User>>();
				users.Count.Returns(1);

				read.Where(x => x.Email == "tester@abc.comx").ReturnsForAnyArgs(users);

				string expectedInvalid = string.Format("A user already exists with the email {0}", command.Email);

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidEmail);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_Empty_Email()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand(null, null, null, "");

				string expectedInvalid = MessagesModel.Required;

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidEmail);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_Invalid_Email_Length()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand(null, null, null, "a".PadLeft(256, 'a') + "@abc.comx");

				string expectedInvalid = string.Format(MessagesModel.MaxLength, "255");

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidEmail);
			}

			[TestMethod]
			public void Validate_Should_Not_Add_User_With_Invalid_Email_Format()
			{
				UserCommand command = UserCommandHandlerTestHelper.GetCommand(null, null, null, "testatabc.comx");

				string expectedInvalid = MessagesModel.InvalidEmail;

				UserCommandResult result = UserCommandHandlerHelper.Validate(command, this.write, this.read);

				Assert.IsFalse(result.Valid);
				Assert.AreEqual(expectedInvalid, result.InvalidEmail);
			}
		}
	}
}
namespace Featurz.Application.Tests.Unit.CommandHandler.User
{
	using System;
	using System.Collections.Generic;
	using Archer.Core.Repository;
	using Featurz.Application.Command.User;
	using Featurz.Application.CommandHandler.User;
	using Featurz.Application.Entity;
	using Featurz.Application.Exceptions;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NSubstitute;

	[TestClass]
	public class AddUserCommandHandlerTest
	{
		[TestClass]
		public class ExecuteTest
		{
			//TODO: Test duplicate key exception.
			[TestMethod]
			[ExpectedException(typeof(DuplicateItemException))]
			public void AddUserCommandHandler_Should_Throws_Exception_When_Adding_User_With_Duplicate_Name()
			{
				AddUserCommandHandler sut = new AddUserCommandHandler();
				IReadRepository<User> read = Substitute.For<IReadRepository<User>>();
				sut.ReadRepository = read;

				string id = "id1";
				DateTime date = DateTime.Now;
				string firstName = "User 1";
				string lastName = "User 1";
				string email = "tester@abc.comx";
				ICollection<string> roles = null;
				ICollection<string> groups = null;
				bool isEnabled = true;

				IList<User> users = new List<User>();
				User user = new User(id, date, email, firstName, lastName, roles, groups, isEnabled);
				users.Add(user);

				read.Where(x => x.Email == Arg.Any<string>()).ReturnsForAnyArgs(users);

				AddUserCommand command = new AddUserCommand(id, date, firstName, lastName, email, roles, groups, isEnabled);

				sut.Execute(command);
			}
		}
	}
}
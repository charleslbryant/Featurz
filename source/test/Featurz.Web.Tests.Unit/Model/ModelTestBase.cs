namespace Featurz.Web.Tests.Unit.Model
{
	using System;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Query;
	using NSubstitute;

	public class ModelTestBase
	{
		protected ICommandDispatcher CommandDispatch { get; private set; }

		protected IConfiguration Config { get; private set; }

		protected IQueryDispatcher QueryDispatch { get; private set; }

		public void InitializeBase()
		{
			this.Config = Substitute.For<IConfiguration>();
			this.QueryDispatch = Substitute.For<IQueryDispatcher>();
			this.CommandDispatch = Substitute.For<ICommandDispatcher>();
		}
	}
}
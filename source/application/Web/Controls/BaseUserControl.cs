namespace Featurz.Web.Controls
{
	using System;
	using Archer.Core.Command;
	using Archer.Core.Configuration;
	using Archer.Core.Query;
	using Featurz.Web.App_Start;
	using Ninject;

	public class BaseUserControl : System.Web.UI.UserControl
	{
		public BaseUserControl()
		{
			this.Config = NinjectWebCommon.Bootstrapper.Kernel.Get<IConfiguration>();
			this.QueryDispatcher = NinjectWebCommon.Bootstrapper.Kernel.Get<IQueryDispatcher>();
			this.CommandDispatcher = NinjectWebCommon.Bootstrapper.Kernel.Get<ICommandDispatcher>();
		}

		public ICommandDispatcher CommandDispatcher { get; set; }

		public IConfiguration Config { get; set; }

		public IQueryDispatcher QueryDispatcher { get; set; }

		public void Navigate(string screen)
		{
			Response.Redirect(screen);
		}

		public string PageTitle { get; set; }
	}
}
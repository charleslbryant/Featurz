namespace Featurz.Api
{
	using System;
	using System.Web.Http;
	using System.Web.Routing;

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			WebApiConfig.Register(GlobalConfiguration.Configuration);
		}
	}
}
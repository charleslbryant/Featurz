// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Microsoft">
//   Copyright © 2014 Microsoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.Featurz.Admin
{
	using System.Web.Routing;
	using App.Featurz.Admin.Routing;

	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Add("Default", new DefaultRoute());
		}
	}
}

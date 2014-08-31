// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Microsoft">
//   Copyright © 2014 Microsoft
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.Featurz.Admin
{
	using System.Web;
	using System.Web.Optimization;

	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/css/core").Include(
				"~/Content/bootstrap.min.css",
				"~/Content/font-awesome.min.css",
				"~/Content/ionicons.min.css"));

			bundles.Add(new StyleBundle("~/css/app").Include(
				"~/Content/AdminLTE.css"));

			bundles.Add(new ScriptBundle("~/js/core").Include(
				"~/Scripts/vendor/angular.min.js"));

			bundles.Add(new ScriptBundle("~/js/app").Include(
				"~/scripts/vendor/jquery-2.1.1.min.js",
				"~/scripts/vendor/bootstrap.min.js",
				"~/scripts/AdminLTE/app.js",
				"~/scripts/vendor/angular-ui-router.js",
				"~/scripts/app.js",
				"~/scripts/filters.js",
				"~/scripts/services.js",
				"~/scripts/directives.js",
				"~/scripts/controllers.js"));
		}
	}
}

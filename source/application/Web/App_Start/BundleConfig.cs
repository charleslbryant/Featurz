namespace Featurz.Web
{
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
				"~/Scripts/vendor/modernizr-2.6.2.js"));

			bundles.Add(new ScriptBundle("~/js/app").Include(
				"~/scripts/vendor/jquery-2.1.1.min.js",
				"~/scripts/vendor/bootstrap.min.js",
				"~/scripts/AdminLTE/app.js"));
		}
	}
}
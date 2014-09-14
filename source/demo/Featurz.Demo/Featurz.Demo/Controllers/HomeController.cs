namespace Featurz.Demo.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using Featurz;

	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (Flag.IsActive("Feature 1"))
			{
				ViewBag.Message = "Feature is active.";
			}
			else
			{
				ViewBag.Message = "Feature is inactive.";
			}
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
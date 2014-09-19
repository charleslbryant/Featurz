namespace Featurz.Web
{
	using System;
	using System.Web.UI;
	using Featurz.Web.Controls;

	public partial class _Default : Page
	{
		protected void LoadPageController()
		{
			string controlPath = this.GetControlPath();
			BaseUserControl control = (BaseUserControl)LoadControl(controlPath);
			this.PageControllers.Controls.Add(control);
			this.Page.Title = this.GetPageTitle(control);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Page.Title = "Dashboard";
			this.LoadPageController();
		}

		private string GetControlPath()
		{
			string controlDirectory = "Features";
			string controlFile = "List";

			if (Page.RouteData.Values["control"] != null)
			{
				controlDirectory = Page.RouteData.Values["control"].ToString();
			}

			if (Page.RouteData.Values["action"] != null)
			{
				controlFile = Page.RouteData.Values["action"].ToString();
			}

			string controlPath = string.Format("/controls/{0}/{1}.ascx", controlDirectory, controlFile);
			return controlPath;
		}

		private string GetPageTitle(BaseUserControl control)
		{
			if (Page.RouteData.Values["control"] == null)
			{
				return "Dashboard";
			}

			return string.IsNullOrWhiteSpace(control.PageTitle) ? string.Empty : control.PageTitle;
		}
	}
}
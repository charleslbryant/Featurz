namespace Featurz.Web.ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using Featurz.Web.Model;

	public class BaseVm
	{
		public BaseVm()
		{
			this.MessageStyle = MessagesModel.MessageStyles.Hidden;
		}

		public string Message { get; set; }

		public MessagesModel.MessageStyles MessageStyle { get; set; }
	}
}
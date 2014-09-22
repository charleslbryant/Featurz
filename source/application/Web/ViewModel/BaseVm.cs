namespace Featurz.Web.ViewModel
{
	using System;
	using Featurz.Application.Message;

	public class BaseVm
	{
		public BaseVm()
		{
			this.MessageStyle = MessagesModel.MessageStyles.Hidden;
		}

		public string Message { get; set; }

		public MessagesModel.MessageStyles MessageStyle { get; set; }

		public bool Valid { get; set; }
	}
}
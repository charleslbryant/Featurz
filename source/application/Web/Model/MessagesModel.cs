﻿namespace Featurz.Web.Model
{
	using System;

	public class MessagesModel
	{
		public static readonly string MaxLength = "Maximum length is {0}.";
		public static readonly string NoItemsFound = "No items found.";
		public static readonly string Required = "Required";
		public static readonly string ItemError = "fa.danger";
		public static readonly string ItemGroupError = "has-error";
		public static readonly string ItemMessage = " - ";
		public static readonly string FormError = "Form is invalid.";

		public enum MessageStyles
		{
			Error,
			Hidden,
			Info,
			Success,
			Warning
		}
	}
}
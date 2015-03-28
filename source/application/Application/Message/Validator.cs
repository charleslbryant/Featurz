namespace Featurz.Application.Message
{
	using System;

	public class Validator
	{
		public static bool IsEmail(string email)
		{
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
		}
	}
}
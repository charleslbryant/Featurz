namespace Archer.Infrastructure.Configuration
{
	using System;
	using Archer.Core.Configuration;

	public class AppConfig : IConfiguration
	{
		public T Get<T>(string key, T defaultValue = default(T), bool throwException = false) where T : IConvertible
		{
			try
			{
				var value = System.Configuration.ConfigurationManager.AppSettings.Get(key);

				if (value == null)
				{
					if (defaultValue == null)
					{
						throw new Exception(string.Format("AppConfig key, {0}, was not found and had no default value.", key));
					}
					return defaultValue;
				}

				var getType = typeof(T);

				if (getType.IsEnum)
				{
					return (T)Enum.Parse(getType, value.ToString(), true);
				}

				return (T)Convert.ChangeType(value, getType);
			}
			catch
			{
				if (throwException)
				{
					throw;
				}
			}

			return defaultValue;
		}

		public void Set<T>(string key, T value) where T : IConvertible
		{
			System.Configuration.ConfigurationManager.AppSettings.Set(key, value.ToString());
		}
	}
}
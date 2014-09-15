namespace Featurz.Application.Exceptions
{
	using System;

	[Serializable]
	public class FeaturzException : Exception
	{
		public FeaturzException()
			: base()
		{
		}

		public FeaturzException(string msg)
			: base(msg)
		{
		}

		public FeaturzException(string msg, Exception ex)
			: base(msg, ex)
		{
		}
	}

}

namespace Featurz.Application.Exceptions
{
	using System;

	[Serializable]
	public class DuplicateItemException : FeaturzException
	{
		public DuplicateItemException(string msg)
			: base(msg)
		{
		}
	}
}

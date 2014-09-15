namespace Featurz.Application.Exceptions
{
	using System;

	[Serializable]
	public class DuplicateFeatureException : FeaturzException
	{
		public DuplicateFeatureException(string msg)
			: base(msg)
		{
		}
	}
}

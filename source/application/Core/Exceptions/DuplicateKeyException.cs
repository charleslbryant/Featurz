namespace Archer.Core.Exceptions
{
	using System;

	[Serializable]
	public class DuplicateKeyException : ArcherException
	{
		public DuplicateKeyException(string msg)
			: base(msg)
		{
		}
	}
}

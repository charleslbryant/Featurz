namespace Archer.Core.Exceptions
{
	using System;

	[Serializable]
	public class ArcherException : Exception
	{
		public ArcherException()
			: base()
		{
		}

		public ArcherException(string msg)
			: base(msg)
		{
		}

		public ArcherException(string msg, Exception ex)
			: base(msg, ex)
		{
		}
	}
}

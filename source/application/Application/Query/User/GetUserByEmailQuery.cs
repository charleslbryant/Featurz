namespace Featurz.Application.Query
{
	using System;
	using Archer.Core.Query;

	public class GetUserByEmailQuery : IQuery
	{
		public GetUserByEmailQuery(string email)
		{
			this.Name = email;
		}

		public string Email { get; private set; }
	}
}
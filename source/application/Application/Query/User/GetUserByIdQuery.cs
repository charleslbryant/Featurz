namespace Featurz.Application.Query.User
{
	using System;
	using Archer.Core.Query;

	public class GetUserByIdQuery : IQuery
	{
		public GetUserByIdQuery(string Id)
		{
			this.Id = Id;
		}

		public string Id { get; private set; }
	}
}
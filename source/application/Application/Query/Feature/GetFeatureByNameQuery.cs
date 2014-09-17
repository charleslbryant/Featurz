namespace Featurz.Application.Query.Feature
{
	using System;
	using Archer.Core.Query;

	public class GetFeatureByNameQuery : IQuery
	{
		public GetFeatureByNameQuery(string name)
		{
			this.Name = name;
		}

		public string Name { get; private set; }
	}
}
namespace Featurz.Application.Query.Feature
{
	using System;
	using Archer.Core.Query;

	public class IsFeatureActiveQuery : IQuery
	{
		public IsFeatureActiveQuery(string name)
		{
			this.Name = name;
		}

		public string Name { get; private set; }
	}
}
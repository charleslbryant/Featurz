namespace Featurz.Application.Feature
{
	using System;
	using Featurz.Application.Entity;

	public interface IFeatureActivationStrategy
	{
		dynamic Strategy { get; set; }

		int Id { get; set; }

		bool IsActive(Feature feature, FeatureContext context);
	}
}

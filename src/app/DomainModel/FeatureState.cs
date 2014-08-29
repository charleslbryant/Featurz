namespace Featurz.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FeatureState
    {
        private Feature feature;
        private bool enabled;

        public FeatureState(Feature feature, bool enabled)
        {
            // TODO: Complete member initialization
            this.feature = feature;
            this.enabled = enabled;
        }
        public bool IsEnabled { get; set; }

        public string StrategyId { get; set; }
    }
}

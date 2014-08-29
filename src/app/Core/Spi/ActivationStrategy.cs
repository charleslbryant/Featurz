using System;
namespace Featurz.Core.Spi
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ActivationStrategy
    {
        public string StrategyId { get; set; }

        internal bool IsActive(DomainModel.FeatureState state, DomainModel.FeatureUser user)
        {
            throw new NotImplementedException();
        }
    }
}

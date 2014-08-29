namespace Featurz.Core.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Featurz.DomainModel;

    public class FeatureProvider
    {
        internal List<Feature> GetFeatures()
        {
            throw new NotImplementedException();
        }

        internal IFeatureMetaData GetMetaData(Feature feature)
        {
            throw new NotImplementedException();
        }
    }
}

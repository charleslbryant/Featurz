using Featurz.DomainModel;
namespace Featurz.Core.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using Featurz.DomainModel;

    public class EmptyFeatureMetaData : IFeatureMetaData
    {
        private Feature feature;

        public EmptyFeatureMetaData(Feature feature) 
        {
            this.feature = feature;
        }

        public String Label
        {
            get { return feature.Name; }
        }

        public bool IsEnabledByDefault
        {
            get { return false; }
        }

        public ICollection<FeatureGroup> Groups
        {
            get { return new List<FeatureGroup>(); }
        }

        public NameValueCollection Attributes
        {
            get { return new NameValueCollection(); }
        }

    }
}

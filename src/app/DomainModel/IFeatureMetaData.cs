namespace Featurz.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    public interface IFeatureMetaData
    {
        NameValueCollection Attributes { get; }
        ICollection<FeatureGroup> Groups { get; }
        bool IsEnabledByDefault { get; }
        string Label { get; }
    }
}

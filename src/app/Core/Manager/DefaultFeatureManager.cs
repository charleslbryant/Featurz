namespace Featurz.Core.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;
    using Featurz.DomainModel;
    using Featurz.Core.Repository;
    using Featurz.Core.Spi;
    using Featurz.Core.User;

    public class DefaultFeatureManager : IFeatureManager
    {
        private string featureManagerName;
        private StateRepository stateRepository;
        private UserProvider userProvider;
        private ICollection<ActivationStrategy> strategies;
        private FeatureProvider featureProvider;

        public DefaultFeatureManager(string featureManagerName, FeatureProvider featureProvider, StateRepository stateRepository)
        {
            this.featureManagerName = featureManagerName;
            this.featureProvider = featureProvider;
            this.stateRepository = stateRepository;
            //this.strategies = Lists.asList(ServiceLoader.load(ActivationStrategy.class).iterator());
            Contract.Ensures(this.strategies != null, "No ActivationStrategy implementations found");
        }

        public string FeatureManagerName
        {
            get { return featureManagerName; }
        }

        public IList<Feature> Features
        {
            get 
            {
                List<Feature> features = featureProvider.GetFeatures();

                if (features == null)
                { 
                    return new List<Feature>();
                }

                return features.AsReadOnly();
            }
        }

        public FeatureUser CurrentFeatureUser
        {
            get { return userProvider.CurrentUser; }
        }

        public IFeatureMetaData GetMetaData(Feature feature)
        {
            Contract.Requires(feature != null, "Feature is required.");
            
            IFeatureMetaData metadata = featureProvider.GetMetaData(feature);
            
            if (metadata != null)
            {
                return metadata;
            }

            return new EmptyFeatureMetaData(feature);
        }

        public bool IsActive(DomainModel.Feature feature)
        {
            Contract.Requires(feature != null, "Feature is required.");

            FeatureState state = stateRepository.GetFeatureState(feature);

            if (state == null)
            {
                return GetMetaData(feature).IsEnabledByDefault;
            }

            if (state.IsEnabled)
            {
                string strategyId = state.StrategyId;

                if (string.IsNullOrEmpty(strategyId))
                {
                    return true;
                }

                FeatureUser user = userProvider.CurrentUser;

                foreach (ActivationStrategy strategy in strategies)
                {
                    if (strategy.StrategyId.Equals(strategyId, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return strategy.IsActive(state, user);
                    }
                }
            }

            return false;
        }

        public FeatureState GetFeatureState(Feature feature)
        {
            Contract.Requires(feature != null, "Feature is required.");

            FeatureState state = stateRepository.GetFeatureState(feature);
            
            if (state == null)
            {
                bool enabled = GetMetaData(feature).IsEnabledByDefault;
                state = new FeatureState(feature, enabled);
            }

            return state;
        }

        public void SetFeatureState(FeatureState state)
        {
            Contract.Requires(state != null, "State is required.");

            stateRepository.SetFeatureState(state);
        }
    }
}

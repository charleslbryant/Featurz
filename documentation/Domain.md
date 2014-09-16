Domain
======


Feature
-------
- Name
- Ticket
- IsEnabled
- IsActive
- Owner
- Activation Strategies

### Activation Strategy ###

* ActivationStrategy - a class that defines the properties that make up a 
specific type of activation strategy.
* FeatureActivationStrategy - the ActivationStrategy instance assigned to a 
feature by unique Id. This object holds the state of the ActivationStrategy that
should result in an active feature.
* ActivationStrategyContext - the ActivationStrategy instance assigned to a 
client request by unique Id with its state set by properties of the client request.
* ActivationStrategyContextMapper - is used to map client request to an 
ActivationStrategyContext.
* ActivationStrategyMatcher - is used to evaluate a FeatureStrategyStrategy vs 
ActivationStrategyContext to determine if it results in an active feature.
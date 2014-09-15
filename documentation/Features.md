Features
========

Domain
------

* Feature
  - Active
  - Activation Strategy

An Activation Strategy has 3 parts:

* StrategyEntity - the properties that make up a specific type of strategy. The 
StrategyEntity is common to all strategies of the same type.
* StrategyMatch - the StrategyEntity property states that result in an active 
feature. The strategy match is specific to one instance of a type of strategy 
and is identified by a unique Id.
* StrategyContext - the StrategyEntity supplied by the client that are used in a 
matching algorithm where the properties are compared to the StrategyMatch to
determine if the feature is active.

Scenarios
---------

###Featurz

1. Is Feature Active
  1. [ ] Active feature.
  1. [ ] Active but disabled feature is inactive.
  1. [ ] Feature active by strategy.
  1. [ ] Feature active by multiple strategies.

###Feature

1. Add Feature
  1. [x] Add new feature. v0.0.1
  1. [x] Add invalid feature returns error. v0.0.1
  1. [ ] Add activation strategy.
1. List Features
  1. [x] List all features. v0.0.1
  1. [ ] List features by active.
  1. [ ] List features by date range.
  1. [ ] List features by enabled.  
  1. [ ] List features by activation strategy.
1. View Feature
  1. [ ] View feature by Id.
  1. [ ] View feature by invalid Id returns error.
  1. [ ] View feature by unknown Id returns error.
  1. [ ] View feature activation strategies.
1. Update Feature
  1. [ ] Update feature.
  1. [ ] Update invalid feature returns error.
  1. [ ] Disable feature.
  1. [ ] Enable feature.
  1. [ ] Update activation strategy.
  1. [ ] Remove activation strategy.
  1. [ ] Last update date.

### User

1. Add User
  1. [ ] Add new user.
  1. [ ] Add invalid user returns error.
1. List Users
  1. [ ] List all users.
  1. [ ] List disabled users.
1. Modify User Roles
  1. [ ] Add new user role.
  1. [ ] Remove user role.

###Feature Activation Strategy
1. [ ] **User:** activate ffor a specific user, user group, user role, user group role.
1. [ ] **Gradual Rollout:** activate for a specific number or percentage of users.
1. [ ] **Release Date:** feature is activated or deactivated on or after a specific date.
1. [ ] **Client IP:** feature is active if user connects from a specific IP or IP range.
1. [ ] **Server IP:** feature is active if served from a specific server IP or IP range.
1. [ ] **HTTP Request:** feature is active based on matching request (e.g. query string, form, cookie).
1. [ ] **Script Engine:** custom strategy with logic implemented by client script.
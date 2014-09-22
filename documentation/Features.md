Features
========

Below are scenario goals for v1.0.0 of Featurz.

Scenarios
---------

###1. Featurz

1. Flag.IsActive Predicate
  1. [ ] Return false for disabled feature. v0.1.0
  1. [ ] Return true for enabled and active feature. v0.1.0
  1. [ ] Return false for enabled and inactive feature. v0.1.0
  1. [ ] Return true for enabled and active feature when all enabled feature activation strategies return true.
  1. [ ] Feature false for enabled and active feature when one or more enabled feature activation strategies return false.

###2. Feature

1. Add Feature
  1. [x] Add new feature. v0.1.0
  1. [x] Add invalid feature returns error. v0.1.0
  1. [ ] Common form.
1. List Features
  1. [x] List all features. v0.1.0
  1. [x] Link to edit feature. v0.1.0
  1. [x] Link to ticket system page for feature's ticket. v0.1.0
  1. [ ] Toggle feature active.
  1. [ ] Toggle feature enabled.
  1. [ ] Common grid list.
      1. [ ] List features by active.
      1. [ ] List features by enabled.  
      1. [ ] List features by date range.
      1. [ ] List features by owner.
      1. [ ] List features by activation strategy.
1. Edit Feature
  1. [x] Edit feature. v0.1.0
  1. [x] Edit invalid feature returns error. v0.1.0
  1. [ ] Common form.
1. Feature Metrics
  1. [ ] Count enabled active features by date range.
  1. [ ] Count enabled inactive features by date range.
  1. [ ] Count enabled features by date range.
  1. [ ] Count calls to Flag.IsActive predicate to enabled feature by date range.

###3. User

1. Add User
  1. [ ] Add new user. v0.1.0
  1. [ ] Add invalid user returns error. v0.1.0
  1. [ ] Common form.
1. List Users
  1. [ ] List all users. v0.1.0
  1. [ ] List users by enabled.
  1. [ ] Common grid list.
1. Edit User
  1. [ ] Edit User. v0.1.0
  1. [ ] Toggle user enabled.
  1. [ ] Common form.

####Role

1. Add User Role
  1. [ ] Add new role. v0.1.0
  1. [ ] Add invalid role returns error. v0.1.0
  1. [ ] Common form.
1. List Roles
  1. [ ] List all roles. v0.1.0
  1. [ ] List roles by enabled. 
  1. [ ] Common grid list.
1. Edit Role
  1. [ ] Edit role. v.0.1.0
  1. [ ] Toggle role enabled.
  1. [ ] Common form.

####Group

1. Add Group
  1. [ ] Add new group. v0.1.0
  1. [ ] Add invalid group returns error. v0.1.0
  1. [ ] Common form.
1. List Groups
  1. [ ] List all groups. v0.1.0
  1. [ ] List groups by enabled. 
  1. [ ] Common grid list.
1. Edit Group
  1. [ ] Edit group. v.0.1.0
  1. [ ] Toggle group enabled.
  1. [ ] Common form.

###4. Feature Activation Strategy

1. [ ] **User:** activate for a specific user, user group, user role, user group role.
1. [ ] **Gradual Rollout:** activate for a specific number or percentage of users.
1. [ ] **Release Date:** feature is activated or deactivated on or after a specific date.
1. [ ] **Client IP:** feature is active if user connects from a specific IP or IP range.
1. [ ] **Server IP:** feature is active if served from a specific server IP or IP range.
1. [ ] **HTTP Request:** feature is active based on matching request (e.g. query string, form, cookie).
1. [ ] **Script Engine:** custom strategy with logic implemented by client script.

Each feature activation strategy should support these scenarios along with any additional specific scenarios:

1. Return true when feature activation strategy criteria is met.
1. Return false when feature activation strategy criteria is not met.
1. Add feature activation strategy.
1. Add invalid feature activation strategy returns error.
1. Edit feature activation strategy.
1. Edit invalid feature activation strategy returns error.
1. Disable feature activation strategy.
1. Enable feature activation strategy.
1. Remove activation strategy.

###5. Common

1. Grid List
  1. [ ] Page list.
  1. [ ] Sort list.
  1. [ ] Filter list.
1. Form
  1. [ ] Client side validation.
    1. [ ] Valid email address.
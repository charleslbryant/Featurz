Just Wondering
==============

- How to integrate feature flags in SDLC?
  - When you have a new ticket for a change to an application when do your create the feature flag?
  - When you are finished developing the feature how do you deliver the feature flag with the feature?
  - How to automate delivery of feature flag from development to production? 
- To enable feature activation by strategy the client needs to send additional 
state besides just the feature name or Id. Should we create an interface or
base class that must be implemented in the client where this state can be passed?

#  #
    //Interface implemented on the client, interface provided by Featurz.dll
    public class Flag : IFlag
    {
        public static bool IsActive(string featureName)
        {
            ClientContext context = SomeMethodToGetContext();
            Featurz.IsActive(featureName, context)
        }
    }
    
    //Provided by Featurz.dll
    public class Featurz
    {
        public static bool IsActive(string featureName, ClientContext context)
        {
            ...
        }
    }

- How to do paging MongoDB?
- How to deal with concurrency in MongoDB?
Web Forms vs MVC
================

With all of the hype over ASP.Net MVC and now client side development backed by 
ASP.Net Web API, many ASP.Net devs have missed the sexy make over to Web Forms. 
Web Forms has had a bad rap because of its attempt to add state to the stateless 
web through the ViewState. The strong dependency on System.Web made testing code 
behinds a pain. I can go on and on, but we all know the troubles. Actually, most 
enterprise class applications I have worked on have been based on the Web Forms
model. You know what? It was never that bad to me. The apps worked. There were
many that were bad, not because of Web Forms, but bad coding practices.

Long Live Web Forms
-------------------

Web Forms was a leap forward over ASP and Microsoft's entry into rapid OOP web
development. It was well received and many large scale application took 
advantage of it. Tool and Control vendors developed products based on it and 
all seemed well with Web Forms. Then one day, we noticed all the hype behind 
Ruby on Rails and MVC and we wanted some of that. I remember trying MVP over Web 
Forms and URL Rewriting. It never satisfied me and when Microsoft announced MVC
I was excited. I eventually moved to MVC on my personal projects, but Web Forms 
lived on in my day job. 

As MVC improved I never really looked at the new changes to Web Forms because 
upgrading Web Forms was never really a thought at my day job. Just keeping the
dinosaur feed and working is what we do. Today, I'm working with an old brittle 
app that we haven't really focused on large changes to the architecture and 
patterns used because breaking production is scary. Actually, we have a plan to 
move to MVC, but after my exercise with the new Web Forms I see that there are 
some things we can do that is not scary and can shore up the architecture to at 
least make it unit testable.

So, I am posting today that Web Forms is still a viable flavor of ASP.Net for
large scale applications. I have been working on an app to manage Feature Flag
or Feature Toggles. The app is named Featurz and I originally planned to code
the administrative site for the app with Angular and Web API. As I struggled to
get a scalable structure for the Angular app, I thought I wonder what this 
would look like in Web Forms and my journey began.

I have not worked with the new and improved Web Forms. Like I said my day job is
spent hacking on a dirty old brownfield implementation of Web Forms with 
remnants of ASP.Net 1.0 (really old). I had two simple goals, use extensionless
URLs like MVC and no logic in code behinds so that it is unit testable.

Differences
-----------

You can view the code in the Featurz.Web project and I just wanted to give a 
brief overview of the high level differences vs MVC. Not taking into account the 
differences in the view templates (ASCX vs Razor), Web Forms approach to HTTP
state management and other concerns with Web Forms, this is how the high level 
structure looks in my implementation of Web Forms vs MVC.

### ASP.Net Web Forms ###

- ASCX
- Model
- Dispatcher
- Repository

### ASP.Net MVC ###

- Controller
- Dispatcher
- Repository

ASCX/Model
----------

There is an extra layer in Web Forms vs MVC.The ASCX is the traditional code
behind, but in this implementation it is just used to bind the view template.
The Model is somewhat comparable to the Controller in that it holds the bulk of
the presentation logic. The ASCX is aware of the Model (it depends on it), but 
the Model has no knowledge of the ASCX. The Model can change the state of the 
View through a View Model which the ASCX binds to view template controls. 
The ASCX passes the View Model to the instance of the Model it created and the 
Model passes it back after it has done its work on it.

Dispatcher/Repository
---------------------

The Dispatcher is where the stack is common between both approaches. The 
Dispatcher can be seen as the service layer or the layer of abstraction 
over the repository. Actually, its not really a service layer, its a lot more 
special. I am following a CQRSish structure for this app and the Dispatcher is 
responsible for dynamically selecting a handler (with the help of Ninject) for 
Commands or Queries and the handler will actually interface with the Repository.

Conclusion
----------

Changes to Web Forms has made it a lot more attractive compared to MVC. They 
both allow routing to extensionless URLs. They are both unit testable. Logic in 
Web Forms is put in the Model and in the Controller in MVC and this is where you 
focus your testing. Although I have heard grumbles of people advocating making
Controllers a lot thinner on logic. Thinner Controllers means you move logic
out of web projects to a more reusable project, so I'm with that.

I felt there was still some boiler plating to get the code behind and model
talking, but I believe what I have can be refactored into a more maintainable
structure. For now Web Forms is back in Vogue for me.
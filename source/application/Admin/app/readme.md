ArcherAppTemplate.Angular 
==================

Extending the concept behind the [ArcherAppTemplate](https://github.com/charleslbryant/ArcherAppTemplate), ArcherAppTemplate.Angular 
provides a template for building Angular applications. There are other ways of 
doing this like the [Angular Seed](https://github.com/angular/angular-seed), 
[Angular-App](https://github.com/angular-app/angular-app), or the awesome 
[Yeoman](http://yeoman.io/) project, but I wanted something that leaned towards 
my warped .Net OOP sensibilities. 

The primary result I wanted was an app structure that was modular and massively
scalable without getting massively ugly and difficult to maintain. Yet, what I have
learned in my many years developing is that one man's easy to maintain is 
another man's hard to maintain, so maintainability if subjective. I am not sure 
if this is maintainable over many years and hundreds of files, but I am 
comfortable so far. I am able to extend the structure by adding additional 
folders where necessary while still keeping thing organized in a way that makes
it easy to find what I'm looking for when there may be hundreds of files.

Another goal was to integrate some of the cool toys that haven't had much play
in the .Net world. I want to use Grunt to build my Angular apps.

Get Ready
---------

If you are going to use this template, you need to do a few things. You will need
Grunt so you have to have Node.js.

### Install Node.js ###

I used [Chocolatey](http://chocolatey.org/)

    > choco install nodejs

### Install Grunt ###

First we need to install the Grunt command line interface (CLI). 

*NOTE: If you have Grunt 0.3 or less you will need to uninstall it first. You can 
use npm view or list command to see if you have it.*

    > npm install grunt-cli -g

Now we need to install Grunt on the project.

Structure
===========

The meat of the application is located in the app folder. If you installed with
NuGet, the app folder should have been added to your project. The app folder is 
broken down into 4 main parts:

1. **root** - The root of the app folder holds app.js which is the main entry point 
and bootstrapper for the application. It also houses the main app 
controllers and constants which has global properties. There is also a 
style.css that has the main style sheet for the application.

1. **common** - This folder holds scripts that are common throughout the application. This would
be mainly directives and filters that should be globally available.

1. **modules** - This folder holds the modules that make up the application. Modules are
separated in to folders that represent the functionality they cover. You 
could say there is a folder for each high level feature of the application.

1. **style** - This folder holds common application styles including preprocessor files like 
Less or SASS.

### Views and Templates ###

Since the template is for .Net, it uses ASP.Net MVC to host the root index view 
and templates. The views and templates are being served from MVC with a 
controller and Razor view that is outside of the app folder. I could do a custom 
Razor route provider to point everything to the app folder, but that will be a
roadmap milestone for now.

### Modules ###

The modules folder follows a convention to make the structure a little simpler 
to deal with. Each modules folder is a self contained application, minus the 
the dependencies it has on the root global items. Each module folder has:

- **controller.js** - this file houses all of the properties and functions needed by 
the views.
- **\*.\*html** - these are the view files. This app uses Razor cshtml files for 
views because I was comfortable with Razor. This is probably not necessary, but 
views can be plain html or another type. Most modules will includes an index 
view which is usually the default view for the module.
- **module.js** - this is where the module is defined including the module routes, 
services and models.
- **style.css** - this is the style file for the module that is added to the module 
views and injected to the main template. The style could be preprocessed.

Additionally, a modules can also contain filters, directives, and other files 
that are specific to the module.

Thanks
------

I borrowed concepts and knowledge from:

- [http://cliffmeyers.com/blog/2013/4/21/code-organization-angularjs-javascript](http://cliffmeyers.com/blog/2013/4/21/code-organization-angularjs-javascript)
- [https://github.com/angular-app/angular-app](https://github.com/angular-app/angular-app)
- [http://briantford.com/blog/huuuuuge-angular-apps](http://briantford.com/blog/huuuuuge-angular-apps)
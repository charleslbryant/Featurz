[![Build status](https://ci.appveyor.com/api/projects/status/uhbjpldafkjbcad6)](https://ci.appveyor.com/project/charleslbryant/featurz)
[![Stories in Ready](https://badge.waffle.io/charleslbryant/Featurz.png?label=ready&title=Ready)](https://waffle.io/charleslbryant/Featurz)
Featurz - toggle me
=======

Featurz is a feature toggle manager for .Net applications. The central feature 
of this tool is to determine if a feature is active or not. Active can be 
determined by multiple strategies.

Featurz was developed on top of the Archer Application Architecture and uses a 
CQRS'ish architecture.

Why use Featurz
---------------

Feature toggles allow you to develop in trunk or your main line without having to worry
about complex branching strategies. If you are working on a new change and it 
isn't ready for production, you can hide it behind a feature toggle and it 
won't be exposed in production. Martin Fowler explains it better, 
http://martinfowler.com/bliki/FeatureToggle.html.
Feature toggles are just simple logic (if/else) that can be implemented without 
a manager like Featurz. Featurz just makes it so much easier to get started with 
toggles and toggle management without the development cost. Additionally, with
Featurz, you have the source code so if something isn't to your liking, you can
change it.

Use Featurz
-----------

You can poke around the project, but nothing is really ready yet. The code in the
repo is a very early stage proof of concept, may not work, has a lot undone, and 
will have UIs and APIs changed drastically.

Wishlist
-----------

- Follow recommendations in the book [Developing Large Web Applications](http://www.amazon.com/Developing-Large-Web-Applications-Producing/dp/0596803028) and 
[Angular App Structure](https://docs.google.com/document/d/1XXMvReO8-Awi1EZXAXS4PzDzdNvV6pGcuaF4Q9821Es/pub)
- Activate features by a dynamic strategy - features can be activated by multiple
strategies that allow the extension of what an active feature means (e.g. active
for 25% of users, active between a date range...).

Contribute
----------

Contributions are welcome, but all contributions must be licensed under [GPL v3](http://www.gnu.org/copyleft/gpl.html).

License
-------

Copyright 2014 Charles Bryant. Licenced under [GPL v3](http://www.gnu.org/copyleft/gpl.html).

References and Inspiration
------
- [Togglz - Feature Flags for the Java platform](http://www.togglz.org/)
- [ArcherAppTemplate](https://github.com/charleslbryant/ArcherAppTemplate) - provides
base template for the Featurz architecture.
- Adam Tibi - the CQRS used is based on his [Code Project article on CQRS](http://www.codeproject.com/Articles/610154/ImplementingplusaplusCQRS-basedplusArchitectureplu). 
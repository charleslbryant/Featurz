[![Codeship Status for charleslbryant/Featurz](https://codeship.io/projects/0d5ab0c0-10d8-0132-f710-3a327caa04b7/status)](https://codeship.io/projects/32911)
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
about complex branching strategies. Martin Fowler explains it better, http://martinfowler.com/bliki/FeatureToggle.html.
You can use feature toggles are just simple logic (if/else) that can be implemented without 
a manager like Featurz, but Featurz makes it so much easier to get started with 
toggles and toggle management without the development cost.

Use Featurz
-----------

You can poke around the project, but nothing is really ready yet. The code in the
repo is a very early stage proof of concept, may not work, has a lot undone, and 
will have UIs and APIs changed drastically.

Contribute
----------

Contributions are welcome, but all contributions must be licensed under [GPL v3](http://www.gnu.org/copyleft/gpl.html).

License
-------

Copyright 2014 Charles Bryant. Licenced under [GPL v3](http://www.gnu.org/copyleft/gpl.html).

Thanks
------
[ArcherAppTemplate](https://github.com/charleslbryant/ArcherAppTemplate)

Adam Tibi - CQRS used in Archer is based on his Code Project article on CQRS, 
http://www.codeproject.com/Articles/610154/ImplementingplusaplusCQRS-basedplusArchitectureplu.
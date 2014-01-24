gems-prometheus
===============

[Prometheus](http://pro.me-the.us) is a text search language for finding complex patterns of text in documents. The language allows a developer to quickly write text matching rules to assist in categorizing documents.


Programmed in C# the scripting engine uses the [GOLD Parsing System](http://goldparser.org/index.htm) to run the scripts, and you'll need to download the Windows installer to recompile Prometheus grammar files. The Visual Studio 2012 project has a pre-build event that executes the GOLD builder. This is only needed if you make changes to the syntax of the language.
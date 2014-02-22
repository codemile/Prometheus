<p align="center"><img src="https://raw2.github.com/thinkingmedia/Prometheus/master/Logo/prometheus-128.png" width="128" height="128" /></p>

#Prometheus

[Prometheus](http://pro.me-the.us) (also called Fire) is a C# coded interpreter that supports object-oriented features with [first-class functions](https://en.wikipedia.org/wiki/First-class_functions). 

Prometheus can express business rules for how a document should be `accepted` or `rejected` using easy to understand grammar. The goal was to create a language that allowed people to read rules long after they were written, and quickly identify what the intent of the rule was.

> Prometheus was intended to be used as an *embedded* tool to allow users to program business rules without much programming knowledge.

## Quick Example

	Accept (Title contains 'Microsoft') 
		And (Sentences contains [/buys?/i,/purchase[sd]?/i,/acquire[sd]?/i] >>> 'Facebook');
	Reject Body contains ['joke'i,'hoax'i,'onion news'i];

The above would mark a document as `accepted` if the title contains the word *"Microsoft"*, and has the sentence *"Today the company purchased the social network FaceBook for $1 dollar."*, and reject the document if it appears to be a joke.

### Example Break-Down

Business rules evaluate to `accepted`, `rejected` or `undecided`. This is purely semantics as Prometheus can provide a variety of results.

Strings in Prometheus represent search terms that can be expressed with flags to indicate their matching behavior, and regular expressions can be written using the `/` character.

An array is used to define a collection of *match any* search term.

The look ahead operator `>>>` was used to indicate that one of the keywords must appear on a sentence before the word "Facebook".

## Why Use Prometheus?

Prometheus was designed to perform text matching in strings and arrays with as as little grammar as possible, and make source code as close as possible to human readable rules.

Under the hood Prometheus is constantly building and compiling regular expressions from your source code. Enabling you to write complex matching terms with much easier to understand grammar. This reduces the chances of making a mistake, and increases the accuracy of your search terms.

## Why Was Prometheus Created

Documents are an ever changing sea of data. While you can perform document searching in C# easily and quickly. The rules you create become fixed within the limits of what was programmed. As the sea of production data changes the rules need to be modified, and that results in recompiling/deploying new C# source code.

Prometheus was created to disconnect the dependency of matching text from the implementation of a C# project. Allowing the rules to be modified without having to change the application that is using Prometheus.

## Test, Test And Test Some More

Anyone who has had to categorize a collection of documents knows that managing your failure rate is only as good as the tests you run. Prometheus comes with built in test grammar that allows you to proof your search terms before they are used on production data.

## Getting Started

Options for using Prometheus in your project:

- Include the Prometheus SDK and use with your .NET project.
- Run Prometheus on the command line using the Fire tool.

## More Information

For general information on the language and its uses.

- [The Manual](http://pro.me-the.us/manual/) contains detailed information about syntax and features.
- [Tutorials](http://pro.me-the.us/category/tutorials/) haves many examples of real-world usages.

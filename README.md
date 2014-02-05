#Prometheus

[Prometheus](http://pro.me-the.us) (also called Fire) is a C# coded interpreter that supports object-oriented features with [first-class functions](https://en.wikipedia.org/wiki/First-class_functions). Prometheus objects are event-driven entity models that implement both the singular model and the model collection. 

Prometheus was created for searching, categorizing and extracting data from text based data models. Such as text documents, blogs, RSS feeds and databases.

##Objects

To declare an object use the `object` syntax. All objects are defined using a constructor function. The constructor function is called when the object is instantiated. Properties and methods are assigned in the constructor to the `this` reference.

	object Foo(x) {
		this.title = x;
		this.DoStuff = function() {
			print this.title;
		};
	}

To create a new object, use the `new` statement to instantiate an `object`:

	var f = new Foo("The title");
	f.DoStuff();

###Private Methods

To declare an object method as private use the `var` keyword.

	object Foo {
		var _private_stuff = function(x) {
			return x * x;
		};
		this.DoStuff = function(x) {
			return _private_stuff(x);
		};
	}

#Events

Any variable can be bound as an event.

	// To declare an event that takes a single argument.
	var x = event(arg);

	// add an event listener
	x += function(arg) {
		print arg;
	};

	// To trigger an event.
	trigger x(3);

To add and remove listener functions.

	var x = event(arg);

	var foo = function(arg) {
	};

	// add listener
	x += foo;

	// remove listener
	x -= foo;

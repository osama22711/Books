# OO Basics
* <span style="color: yellow">Composition</span> describes a class that refrences one or more objects of other classes in instance variables.
* <span style="color: yellow">Abstraction</span> is a general idea rather than one relating to a particular object, person, or situation.
* <span style="color: yellow">Encapsulation</span> is the restricting of direct access to some of an object's components.
* <span style="color: yellow">Polymorphism</span> is the ability of a variable, function or object to take on multiple forms.
* <span style="color: yellow">Inheritance</span> is the mechanism of basing an object or class upon another object or class.
* <span style="color: yellow">Loose-coupling</span> in which components are weakly associated (have breakable relationship) with each other, and so, changes in one component least affect existence or performance of another component. Loose coupling is the opposite of <span style="color: orange">tight coupling</span>, Loosely coupled designs allow us to build flexible OO systems that can handle change because they minimize the interdependency between objects.
* <span style="color: yellow">Delegation</span> refers generally to one entity passing something to another entity
  
----
# OO principles
1. Identify the aspects of your application that vary and seperate them from what stays the same
2. Program to an interface, not an implementation.
3. Favor composition over inheritance
4. Strive for loosely coupled designs between objects that interact.
5. Classes should be open for extension, but closed for modifications (as the <span style="color: orange">design pattern guru</span> said: code should be closed to change like the lotus flower in the evening, yet open to extension like the lotus flower in the morning)

----
# OO Patterns
* <span style="color: yellow">The Strategy Pattern</span>: defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it. [ We used it in <span style="color: orange">Testing Duck behaviors</span> application in chapter 1]
* <span style="color: yellow">The Observer Pattern</span>: defines a one-to-many dependency between objects so that when one object changes state, all of its dependents are notified and updated automatically.
* <span style="color: yellow">The Decorator Pattern</span>: attaches additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.

# Bullet points
1. * Knowing the OO basics does not make you a good OO designer.
   * Good OO designs are reusable, extensible and maintainable.
   * Patterns show you how to build systems with good OO design qualities.
   * Patterns are proven object-oriented experience.
   * Patterns don't give you code, they give you general solutions to design problems. You apply them to your specific application.
   * Patterns aren't invented, they are discovered.
   * Most patterns and principles address issues of change in software.
   * Most patterns allow some part of a system to vary independently of all other parts.
   * We often try to take what varies in a system and encapsulate it.
   * Patterns provide a shared language that can maximize the value of your communication with other developer.
2. * The Observer Pattern defines a one-to-many relationship   between objects.
   * Subjects, or as we also know them, Observables, update Observers using a common interface.
   * Observers are loosely coupled in that the Observable knows nothing about them, Other than that they implement the Observer interface.
   * You can push or pull data from the Observable when using the pattern (pull is considered more "correct").
   * Don't depend on a specific order of notification for your Observers.
   * Java has several implementations of the Observer Pattern, including the general purpose java.util.Observable.
   * Watch out for issues with the java.util.Observable implementation.
   * Don't be afraid to create your own Observable implementation if needed.
   * Swing makes heavy use of the Observer Pattern, as do many GUI frameworks does.
   * You'll also find the pattern in many other places, including JavaBeans and RMI.
3. * Inheritance is one form of extension, but not necessarily the best way to achieve flexibility in our designs.
   * In our designs we should allow behavior to be extended without the need to modify existing code.
   * Composition and delegation can often be used to add new behaviors at runtime.
   * The Decorator Pattern provides an alternative to subclassing for extending behavior.
   * The Decorator Pattern involves a set of decorator classes that are used to wrap concrete components.
   * Decorator classes mirror the type of the components they decorate. (in fact, they are the same type as the components they decorate, either through inheritance or interface implementation.)
   * Decorators change the behavior of their components by adding new functionality before and/or after (or even in place of) method calls to the component.
   * You can wrap a component with any number of decorators.
   * Decorators are typically transparent to the client of the component; that is, unless the client is relying on the component's concrete type.
   * Decorators can result in many small objects in our design, and overuse can be complex.

----
> Reached page: <span style="color: yellow;">109</span>
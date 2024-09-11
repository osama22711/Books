- [Foreword](#foreword)
    - [Japanese 5S methodology](#japanese-5s-methodology)
- [Chapter 2: Meaningful Names](#chapter-2-meaningful-names)
- [Chapter 3: Functions](#chapter-3-functions)
- [Chapter 4 - Comments](#chapter-4---comments)
- [Chapter 5 - Formatting](#chapter-5---formatting)
- [Chapter 6 - Objects and Data Structures](#chapter-6---objects-and-data-structures)
- [Chapter 9 - Unit Tests](#chapter-9---unit-tests)
- [Chapter 10 - Classes](#chapter-10---classes)
- [Chapter 11 - Systems](#chapter-11---systems)
- [Chapter 12 - Emergence](#chapter-12---emergence)
  - [Simple Design Rule 1: Runs All the Tests](#simple-design-rule-1-runs-all-the-tests)
  - [Simple Design Rule 2: Refactoring](#simple-design-rule-2-refactoring)
  - [Simple Design Rule 3: Expressive](#simple-design-rule-3-expressive)
- [Chapter 17 - Smells and Heuristics](#chapter-17---smells-and-heuristics)
  - [Comments](#comments)
  - [Environment](#environment)
  - [Functions](#functions)
  - [General](#general)
  - [Names](#names)
  - [Tests](#tests)



# Foreword

### Japanese 5S methodology

The 5S methodology is a workplace organization and efficiency system that originated in Japan. The 5S's stand for:

1. **Seiri (Sort)**: The first step involves sorting and organizing items in the workspace. Identify what is necessary and remove what is unnecessary. This step helps in reducing clutter and improving efficiency.

2. **Seiton (Set in order)**: Once you've sorted things out, the next step is to arrange the necessary items in a logical and organized manner. Everything should have a designated place, making it easy to find and use.

3. **Seiso (Shine)**: This step focuses on cleaning and maintaining the workspace. Regular cleaning and maintenance ensure that the workplace remains in good condition and that any issues are addressed promptly.

4. **Seiketsu (Standardize)**: After sorting, setting in order, and shining, it's important to establish standardized procedures and practices to maintain the improved work environment. This involves creating and implementing clear guidelines for how things should be done.

5. **Shitsuke (Sustain)**: Sustaining the 5S improvements is the final step. This involves creating a culture of continuous improvement where all employees are responsible for maintaining the 5S practices and looking for ways to make further improvements.

The 5S methodology is often used in manufacturing and production environments to increase efficiency, reduce waste, and create a safer and more organized workspace. However, it can also be applied in other industries and settings to improve organization and productivity.

# Chapter 2: Meaningful Names
1. Use Intention-Revealing Names
   - Bad code:
    ```csharp
    int d; // elapsed time in days
    ```

   - Good code:
   ```csharp
    int elapsedTimeInDays;
   ```

2. Avoid Disinformation (`XYZControllerHammerHandlerForEfficientDada` , `XYZControllerHammerHandlerForBadPePePe`)
3. Make Meaningful Distinctions
    
    Which one to use??!
    ```csharp
    getActiveAccount();
    getActiveAccounts();
    getActiveAccountInfo();
    ```

4. Use Pronounceable Names

   - Bad Code 
    ```csharp
    public class DtaRcrd102 {
        private Date genymdhms;
        private Date modymdhms;
        private final String pszqint = "102";
        /* ... */
    }
    ```

    - Good Code 
    ```csharp
    public class Customer {
        private Date generationTimestamp;
        private Date modificationTimestamp;
        private final String recordId = "102";
        /* ... */
    }
    ```
5. Use Searchable Names
6. Avoid Mental Mapping

    What is "`i`", "`j`", "`x`" ?!
    ```csharp
    for (var i = 0; i<something; i++) {
        for (var j = 0; j<something2; j++) {
            for (var x = 0; x<something3; x++) {
            }
        }
    }
    ```
7. Pick One Word Per Concept (`get, fetch, etc...`)
8. Use Solution Domain Names
9.  Use Problem Domain Names
10. Add Meaningful Context
11. Don't Pun (using the same word for two purposes)
12. Use Nouns as Class Names
13. Use Verbs as Method Names (`get, set, fetch, etc...`)

# Chapter 3: Functions

1. Functions should be small
   - 3-4 lines is a proper function
   - No more than one or two indent levels
   - Function calls should be inside either `if` or `while`

   ```csharp
   public static string renderPageWithSetupsAndTeardowns(PageData pageData, boolean isSuite) {
       if (isTestPage(pageData)) {
           includeSetupAndTeardownPages(pageData, isSuite);
       }
       return pageData.getHTML();
   }
   ```

   - More than three argument isn't recommended

   - Use verbs in the function name

   - Functions should either do something or answer something
( Doing both often leads to confusion. )

2. Do one thing

   - Functions should do one thing. They should do it well. They should do it only.

   - To know if the function do one thing: see if you can extract a function from it without restating its implementation

   - Make it clear for the user about the output of the function

   - Name should reflect only one thing
( No side effects should be there )

3. Functions should be read seamlessly from top to bottom: The Stepdown rule

   - Short
   - One Thing
   - Keeping the abstraction level consistent

4. Use descriptive Names

   - A long descriptive name is better than a short enigmatic name. 
   - A long descriptive name is better than a long descriptive comment
   - Easy to read words of the function
   - Be consistent in naming functions

5. General output argument should be avoided

   ```csharp
   public void appendFooter(StringBuffer report)
   
   // report is being used as an input
   // being modified and returned again to be used
   ```

   ```csharp
   report.appendFooter();
   
   // It's clear that it will append the report to the footer
   ```
   
   - In general output arguments should be avoided. If your function must change the state of something, have it change the state of its owning object.

6. DRY ( Don't repeat yourself )

   - Taking out duplicated code leads to a more clear, easy to understand code

   - Duplication may be the root of all evil in software

7. Stuctured Programming ( Dijkstra's way )

   - functions or block of code should have one entry and one exit
( Single Entry Single Exit rule)

8. How do you write functions like the above?

   - Software is like any other kind of writing

   - You get your thoughts down

   - First draft is ugly

   - Through the following, they become the way we like:
      * Splitting out functions
      * Changing names
      * Eliminating duplication

9. Conclusion

   - Every system is built from a domain-specific language
   - Functions are its verbs
   - Classes are its nouns

Overall functions should be short, well named and nicely organized.

# Chapter 4 - Comments

  - The proper use of comments is to compensate for our failure to express ourself in code
  - Comment lie not intentionally because programmers can't maintain them
  - Comments delude and mislead, they are worse than no comments.
  - Any comment that forces you to look in another module for the meaning of that comment has failed to communicate to you.
  - It is just silly to have a javadoc for every function or every variable must have a comment.

# Chapter 5 - Formatting

1. The purpose of formatting
   - Code formatting is about communication, and communication is the professional developer's first order of business.
   - The coding style and readability set precedents that continue to affect maintainability and extensibility long after the original code has been changed beyond recognition
  
2. The newspaper metaphor
   - We would like a source file to be like a newspaper article
   - The name should be simple but explanatory
   - The name, by itself, should be sufficient to tell us whether we are in the right module or not.
   - The topmost parts of the source file should provide the high-level concepts and algorithms.
   - Detail should increase as we move downward, until at the end we find the lowest level functions and details in the source file.

3. Vertical openness between concepts
   - Each blank line is a visual cue that identifies a new and separate concept. As you scan down the listing, your eye is drawn to the first line that follows a blank line.

4. Vertical distance
   - Concepts that are closely related, should be kept vertically close to each other.
   - If one function calls another, they should be vertically close, and the caller should be above the callee, if at all possible.

5. Team rules
   - Every programmer has his own favorite formatting rules, but if he works in a team, then the team rules.

# Chapter 6 - Objects and Data Structures

1. Data/Object Anti-Symmetry
   - Procedural code makes it hard to add new data structures because all the functions must change
   - OO code makes it hard to add new features because all the classes must change
   - The things that are hard for OO are easy for procedures, and the things that are hard for procedures are easy for OO
   - Mature programmers know that the idea that everything is an object is a myth. Sometimes your really do want simple data structures with procedures operating on them.
  
2. The Law of Demeter
   - A module should not know about the innards of the objects it manipulates
   - The method should not invoke methods on objects that are returned by any of the allowed functions. In other words, talk to friends, not to strangers.
   - For understanding this rule view [Train Wrecks](#train-wrecks)

3. Train Wrecks
   - This kind if code is often called a train wreck because it look like a bunch of coupled train cards.
   - Chains of calls like the following are generally considered ti be sloppy style and should be avoided
      ```csharp
         final String outputDir = ctxt.getOptions().getScrachDir().getAbsolutePath();
      ```
   - This is hard to track each function and what it returns and, per the law of demeter it's not acceptable but, if it were variables calling variables (object), it's totally fine.
      ```csharp
         final String outputDir = ctxt.options.scratchDir.absolutePath;
      ```
   - It is usually best to split them up as follows:
      ```csharp
         Options opts = ctxt.getOptions();
         File scratchDir = opts.getScratchDir()
         final String outputDir = scratchDir.getAbsolutePath();
      ```
# Chapter 9 - Unit Tests

   - If you don't keep your tests clean, you will lose them. And without them, you lose the very thing that keeps your production code feasible
   - The Build-Operate-Check pattern (Arrange Act Assert) is split into three parts:
     - Step1: Build up the test data
     - Step2: Operate on that test data
     - Step3: Checks that the operation yielded the expected results
     - Benefit: The vast majority of annoying detail has been eliminated. The tests get right to the point and use only the data types and functions that they truly need. Anyone who reads these tests should be able to work out what they do very quickly, without being misled or overwhelmed by details.
   - Tests should be written to test one concept and minimize the number of asserts per concept
     - Bad test example:
     - ```java
        public void testAddMonths() {
          SerialDate d1 = SerialDate.createInstance(31, 5, 2004);
          
          SerialDate d2 = SerialDate.addMonths(1, d1);
          assertEquals(30, d2.getDayOfMonth());
          assertEquals(6, d2.getMonth());
          assertEquals(2004, d2.getYYYY());
          
          SerialDate d3 = SerialDate.addMonths(2, d1);
          assertEquals(31, d3.getDayOfMonth());
          assertEquals(7, d3.getMonth());
          assertEquals(2004, d3.getYYYY());
            
          SerialDate d4 = SerialDate.addMonths(1, SerialDate.addMonths(1, d1));
          assertEquals(30, d4.getDayOfMonth());
          assertEquals(7, d4.getMonth());
          assertEquals(2004, d4.getYYYY());
        } 
       ``` 
      - It's not multiple asserts in each section that causes the problem. Rather it is the fact that there is more than one concept being tested.
      - ### Clean tests should follow five rules (F.I.R.S.T.)
        - **F** -  Fast Tests should be fast. They should run quickly. When tests run slow, you won't want to run them frequently. IF you don't run them frequently, you won't find problems early enough to fix them easily. You won't feel as free to clean up the code. Eventually the code will begin to rot.
        - **I** - Independent Tests should not depend on each other. One test should not set up the conditions for the next tests. You should be able to run each test independently and run the tests in any order you like. WHen tests depend on each other, then the first one to fail causes a cascade of downstream failures, making diagnosis difficult and hiding downstream defects.
        - **R** - Repeatable Tests should be repeatable in any environment. You should be able to run the tests in the production environment, in the QA environment, and on your laptop while riding home on the train without a network. If your tests aren't repeatable in any environment, then you'll always have an execuse for why they fail. You'll also find yourself unable to run tests when the environment isn't available.
        - **S** - Self-Validating The tests should have a boolean output. Either they pass or fail. You should not have to read through a log fail to tell whether the tests pass. If the tests aren't self-validating, then failure can become subjective and running the tests can require a manual evaluation.
        - **T** - Timely the tests need to be written in a timely fashion. Unit tests should be written just before the production code that makes them pass. If you write tests after the production code. then you may find the production code to be hard to test. You may decide that some production code is too hard to test. You may not design the production code to be testable.

# Chapter 10 - Classes
  - This chapter can be better understood with design patterns, refer to a previous book "Head First Design Patterns"
  - The first rule of classes is that they should be small
  - With functions we measured size by counting physical lines.
  - With classes we use a different measure. We count responsibilities.
  - The single responsibility principle
    - states that a class or a module should have one, and only one, reason to change, example below:
    - ```java
      public class Version {
        public int getMajorVersionNumber();
        public int getMinorVersionNumber();
        public int getBuildNumber();
      }
      ```
   - Difference between having a huge class or a separated small classes is like asking the following question:
     - Do you want your tools organized into toolboxes with many small drawers each containing well-defined and well-labeled components? Or do you want a few drawers that you just toss everything into?
   - Cohesion
     - Classes should have a small number of instance variable. 
     - Each of the methods of a class should manipulate one or more of those variables.
     - In general the more variables a method manipulates the more cohesive that method is to its class.
     - A class in which each variable is used by each method is maximally cohesive
     - Just the act of breaking large functions into smaller functions causes a proliferation of classes. Consider a large function with many variables declared within it. Let's say you want to extract one small part of that function into a separate function. However, the code you want to extract uses four of the variables declared in the function. Must you pass all four of those variables into the new function as arguments? Not at all! If we promoted those four variables to instance variables of the class, then we could extract the code without passing any variables at all. It would be easy to break the function up into small pieces. Unfortunately, this also means that our classes lose cohesion because they accumulate more and more instance variables that exist solely to allow a few functions to share them. But wait! If there are a few functions that want to share certain variables, doesn't that make them a class in their own right? Of course it does. When classes lose cohesion, split them!
    
# Chapter 11 - Systems
  - Software systems are unique compared to physical systems. Their architectures can grow incrementally, if we maintain the proper separation of concerns.

# Chapter 12 - Emergence
  - A design is "simple" if it follows these rules:
    - Runs all the tests
    - Contains no duplication
    - Expresses the intent of the programmer
    - Minimizes the number of classes and methods

   ## Simple Design Rule 1: Runs All the Tests
   - A system might have a perfect design on paper, but if there is no simple way to verify that the system actually works as intended, then all the paper effort is questionable.
   - Systems that aren't testable aren't verifiable. Arguably, a system that cannot be verified should never be deployed.
      - Should have:
         - SRP: Single Responsibility Principle
         - Loosely coupled
         - DIP: Dependency Inversion Principle - Depends on abstractions
   ## Simple Design Rule 2: Refactoring
   - For each few lines of code we add, we pause and reflect on the new design.
   - This is also where we apply the final three rules of simple design:
        - Eliminate duplication
        - Ensure expressiveness
        - Minimize the number of classes and methods
   ## Simple Design Rule 3: Expressive
   - The most likely next person to read the code will be you.
   - So take a little pride in your worksmanship. Spend a little time with each of your functions and classes. Choose better names, split large functions into smaller functions, and generally just take care of what you've created. Care is a precious resource
   - Clean code is all about care.

# Chapter 17 - Smells and Heuristics
   - The list that follows includes many of Martin's smells and adds many more of Uncle Bob's. It also includes other pearls and heuristics that Uncle Bob uses.
   ## Comments
   1. Inappropriate Information
        1. meta-data such as authors, last-modified date should not be a comment
        2. Comments should be reserved for technical notes about the code and design.
   2. Obsolete Comment
        1. A comment that has gotten old, irrelevant, and incorrect is obsolete.
   3. Redundant Comment
        1. A comment is redundant if it describes something that adequately describes itself.
        2. Comments should say things that code cannot say for itself.
   4. Poorly Written Comment
        1. A comment worth writing is worth writing well.
   5. Commented-Out Code
        1. The code sits there and rots, getting less and less relevant with every passing day.
        2. When you see commented-out code, delete it! Don't worry, the source code control system still remembers it, If anyone really needs it, he or she can go back and check out a previous version. Don't suffer commented-out code to survive.
   ## Environment
   1. Build Requires More Than One Step
         1. You should not need a sequence of arcane commands or context dependent scripts in order to build the individual elements.
         2. You should be able to check out the system with ome simple command and then issue one other simple command to build it.
   2. Tests Require More Than One Step
         1. You should be able to run all unit tests with just one command
   ## Functions
   1. Too Many Arguments
         1. More than three is very questionable and should be avoided with prejudice.
   2. Output Arguments
         1. Readers except arguments to be inputs, not outputs.
   3. Flag Arguments
         1. Boolean arguments loudly declare that function does more than one thing therefore, boolean input is not recommended.
   4. Dead Function
         1. Methods that are never called should be discarded 
   ## General
   1. Multiple Languages in One Source File
         1. The ideal is for a rouce file to contain one, and only one, language
         2. React???
   2. Obvious Behavior Is Unimplemented
         1. Following "The Principle of Least Surprise" any function or class should implement the behaviors that another programmer could reasonably expect.
         2. When an obvious behavior is not implemented, readers and users of the code can no longer depend on their intuition about function names, They lose their trust in the original author and must fall back on reading the details of the code.
   3. Incorrect Behavior at the Boundaries
         1. Don't rely on your intuition. Lookf or every boundary condition and write a test for it
         2. Don't trust your code, and confirm your code.
   4. Overridden Safeties
         1. Turning off certain compiler warnings (or all warnings!) is always risky
         2. Turning off failing tests and telling yourself you'll get them to pass later is a bad as pretending your credit cards are free money.
   5. Duplication
         1. Coding becomes faster and less error prone because you have raised the abstraction level
         2. Most of the design patterns that have appeared in the last fifteen years are simply well-known ways to eliminate duplication.
   6. Code at Wrong Level Of Abstraction
         1. Consider the following code:
            ```java
              public interface Stack {
                Object pop() throws EmptyException
                void push(Object o) throws FullException;
                double percentFull;
              }

              class EmptyException extends Extension {}
              class FullException extends Extension {}
            ```
         2. The `percentFull` function is at the wrong level of abstraction. Although there are many implementations of `Stack` where the concept of fullness is reasonable, there are other implementations that simply could not know how full they are. So the function would be better placed in a derivative interface such as `BoundedStack`
   7. Base Classes Depending on THeir DErivatives
         1. Deploying derivatives and bases in different jar files and making sure the base jar files know nothing about the contents of the derivative jar files allow us to deploy our systems in discrete and independent components.
   8. Too Much Information
         1. A well-defined interface does not offer very much functions to depend upon, so coupling is low.
   9. Dead Code is code that isn't executed
         1.  You find it in the body of an `if` statement that checks for a condition that can't happen
         2.  You find it in the `catch` block of a `try` that never `throws`.
         3.  You find it in little utility methods that are never called
         4.  or `switch/case` conditions that never occur
   10. Vertical Separation
          1.  Variables and function should be defined close to where they are used.
          2.  Local variables should be declared just above their first usage
          3.  Private functions should be defined just below their first usage
          4.  Finding a private function should just be a matter of scanning downward from the first usage.
   11. Inconsistency
          1.  If you do something a certain way, do all similar things in the same way. this goes back to the principle of least surprise.
          2.  If within a particular function you use a variable named `response` to hold an `HttpServletResponse`, then use the same variable name consistently in the other functions that use `HttpServletResponse` objects. If you name a method ` processVerificationRequest`, then use a similar name, such as `processDeletionRequest`, for the methods that process other kinds of requests.
          3.  Simple consistency like this, when reliably applied, can make code much easier to read and modify.
   12. Clutter
          1. Variables that aren't used
          2. functions that are never called
          3. comments that add no information
          4. All these things are clutter and should be removed. Keep your source files clean, well organized and free of clutter.
   13. Artificial Coupling
         1.  Things that don't depend upon each other should not be artificially coupled. For example, general `enums` should not be contained within more specific classes because this forces the whole application to know about these more specific classes.
   14. Feature Envy
         1.  The methods of a class should be interested in the variables and functions of the class they belong to, and not the variables and functions of other classes.
         2.  Feature Envy exposes the internals of one class to another
   15. Selector Arguments
         1.  It is better to have many functions than to pass some code into a function to select the behavior
   16. Obscured Intent
         1.  It is worth taking the time to make the intent of our code visible to our readers.
   17. Misplaced Responsibility
         1.  One of the most important decisions a software developer can make is where to put code.
         2.  The principle of least surprise comes into play here. Code should be placed where a reader would naturally expect it to be.
   18. Inappropriate Static
         1.  Static functions should not operate on any particular objects and gets all it's data from it's arguments.
   19. Understand the Algorithm
         1.  Lots of very funny code is written because people don't take the time to understand the algorithm
         2.  So before writing any code, understand the written one first.
         3.  Often the best way to gain this knowledge and understanding is to refactor the function into something that is so clean and expressive that its obvious how it works.
   20. Follow Standard Conventions
         1.  Every team should follow a coding standard based on common industry norms. This coding standard should specify things like where to declare instance variables; how to name classes, methods, and variables; where to put braces and son on. The team should not need a document to describe these conventions because their code provides the examples.
   ## Names
  1.  Choose Descriptive Names
         1. Names in software are 90 percent of what make software readable
  2. Use Standard Nomenclature Where Possible
         1. Names are easier to understand if they are based on existing conventions or usage. For example, if you are using the `DECORATOR` pattern, you should use the word `Decorator` in the names of the decorating classes. For example, `AutoHangupModemDecorator` might be the name of a class that decorates a `Modem` with the ability to automatically hang up at the end of a session.
   ## Tests
   1. Insufficient Tests
         1. The tests are insufficient so long as there are conditions that have not been explored by the tests or calculations that have not been validated.
   2.  Use a Coverage Tool
         1. They make it easy to find modules, classes, and functions that are insufficiently tested.


---
> Book is done on `11/09/2024`
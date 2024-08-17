- [Foreword](#foreword)
    - [Japanese 5S methodology](#japanese-5s-methodology)
- [Chapter 2: Meaningful Names](#chapter-2-meaningful-names)
- [Chapter 3: Functions](#chapter-3-functions)
- [Chapter 4 - Comments](#chapter-4---comments)
- [Chapter 5 - Formatting](#chapter-5---formatting)
- [Chapter 6 - Objects and Data Structures](#chapter-6---objects-and-data-structures)
- [Chapter 9 - Unit Tests](#chapter-9---unit-tests)
- [Chapter 10 - Classes](#chapter-10---classes)



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
    

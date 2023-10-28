- [Foreword](#foreword)
    - [Japanese 5S methodology](#japanese-5s-methodology)
- [Chapter 2: Meaningful Names](#chapter-2-meaningful-names)
- [Chapter 3: Functions](#chapter-3-functions)



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
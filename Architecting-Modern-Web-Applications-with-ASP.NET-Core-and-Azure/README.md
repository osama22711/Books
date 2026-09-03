# Info
- Book: **Architecting Modern Web Applications with ASP.NET Core and Azure**
- Started Reading: **03/09/2026**
- Book cover: ![Book Cover](imgs/book-cover.png)
- Available for free on: [Github Repo](https://github.com/dotnet-architecture/eBooks/tree/main/current/architecting-modern-web-apps-azure)

# Table of Contents
- [Info](#info)
- [Table of Contents](#table-of-contents)
- [Ways of building web applications](#ways-of-building-web-applications)
- [Common Design Principles](#common-design-principles)
  - [1. Separation of concerns](#1-separation-of-concerns)
  - [2. Encapsulation](#2-encapsulation)
  - [3. Dependency inversion](#3-dependency-inversion)
  - [4. Explicit dependencies](#4-explicit-dependencies)
  - [5. Single responsibility](#5-single-responsibility)

# Ways of building web applications
1. **Traditional web applications**
    - Your application’s client-side requirements are simple or even read-only. 
    - Your application needs to function in browsers without JavaScript support. 
    - Your application is public-facing and benefits from search engine discovery and referrals. 
2. **Single Page Applications (SPA)**
   - Your application must expose a rich user interface with many features
   - Your team is familiar with JavaScript, TypeScript, or Blazor WebAssembly development.
   - Your application must already expose an API for other (internal or public) clients. 

# Common Design Principles
## 1. Separation of concerns
This principle asserts that software should be separated based on the kinds of work it performs
## 2. Encapsulation
Different parts of an application should use encapsulation to insulate them from other parts of the application
## 3. Dependency inversion
The direction of dependency within the application should be in the direction of abstraction, not implementation details

![Direct Dependency Graph](imgs/direct-dependency-graph.png)
![Inverted Dependency Graph](imgs/inverted-dependency-graph.png)

- **Direct Dependency (Tight Coupling)**: A high-level module (your business logic) directly depends on a low-level module (your database or external service). The high-level code is forced to change whenever the low-level code changes.

- **Dependency Inversion (Loose Coupling)**: A high-level module defines an interface (a contract) of what it needs. The low-level module then implements that interface. Both depend on the abstraction (the interface), but crucially, the high-level module owns the interface.

## 4. Explicit dependencies
A class should publicly and clearly request (via its constructor) all the external collaborators it needs to do its job. It should never hide or "magically" create them internally.

If your class needs something to work (like a database, an email sender, or a logger), it must ask for it in the constructor. It should not go searching for it or creating it secretly inside a method

## 5. Single responsibility
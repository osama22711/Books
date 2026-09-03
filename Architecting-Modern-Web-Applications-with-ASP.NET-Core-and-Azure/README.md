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
  - [6. Don’t repeat yourself (DRY)](#6-dont-repeat-yourself-dry)
  - [7. Persistence ignorance (PI)](#7-persistence-ignorance-pi)
  - [8. Bounded contexts](#8-bounded-contexts)
- [Web applications architectures](#web-applications-architectures)
  - [Monolith](#monolith)
  - [N-Layer](#n-layer)
- [Clean](#clean)
- [Vertical Slice](#vertical-slice)
- [Modular Monolith](#modular-monolith)

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
An architectural principle similar to separation of concerns

It states that objects should have only one  responsibility and that they should have only one reason to change. Specifically, the only situation in which the object should change is if the manner in which it performs its one responsibility must be updated

## 6. Don’t repeat yourself (DRY)
The application should avoid specifying behavior related to a particular concept in multiple places as this practice is a frequent source of errors.

Don't write the same logic, business rule, or configuration in multiple places. Write it once, and reuse it everywhere else

## 7. Persistence ignorance (PI)
Database models `Customer` or `Order` should have absolutely no idea how they are saved to a database

1. **No Database Code**: A Customer class does not contain any SQL queries, ConnectionStrings, or Save() methods.
2. **No Special Inheritance**: It does not have to inherit from a special database base class (like DbEntity or Record).
3. **No Database Annotations**: It does not use database-specific attributes (like [Table], [Column], or [Key]).

Persistence Ignorance frees your business logic so it doesn't care if you use SQL, MongoDB, or a CSV file.

A popular term used here is `POCO` class which is a simple, plain C# (or VB.NET) class that doesn't inherit from a special framework base class, and doesn't implement heavy framework interfaces. It's just a normal class.

`POCO` stands for Plain Old CLR Object (CLR stands for Common Language Runtime, the execution engine for .NET).

## 8. Bounded contexts
Bounded contexts are a central pattern in Domain-Driven Design. They provide a way of tackling complexity in large applications or organizations by breaking it up into separate conceptual modules. 

Each conceptual module then represents a context that is separated from other contexts (hence, bounded), and can evolve independently.

Imagine a large e-commerce company.
1. **The Sales Team thinks of a Customer as**: A person with a shopping cart, shipping address, and payment method.
2. **The Support Team thinks of a Customer as**: A person with open tickets, satisfaction scores, and a loyalty tier.
3. **The Billing Team thinks of a Customer as**: A legal entity with a tax ID, invoice history, and account balance.

# Web applications architectures
> “If you think good architecture is expensive, try bad architecture.” - Brian Foote and Joseph Yoder 

Most traditional .NET applications are deployed as single units corresponding to an executable or a  single web application running within a single IIS appdomain. This approach is the simplest deployment model and serves many internal and smaller public applications very well. However, even given this single unit of deployment, most non-trivial business applications benefit from some logical separation into several layers. 

## Monolith

A monolithic application has three core characteristics:
1. **Self-contained behavior**: The core of its functionality runs within its own single process.
2. **Single deployment unit**: The entire application is compiled and deployed as one package.
3. **Horizontal scaling is "all or nothing"**: If you need to scale out, you must duplicate the entire application (UI, business logic, and data access) across multiple servers or VMs. You cannot scale individual components independently.

The smallest possible architecture is a single project.

**Definition**: All logic—Presentation (UI), Business (Domain), and Data Access (Infrastructure)—resides in one project, compiles to one assembly, and deploys as one unit.

**Default State**: When you create a new ASP.NET Core project (via Visual Studio or CLI), it starts out as exactly this type of monolith.

In a single-project app, you achieve Separation of Concerns using folders (not projects).

![Monolith Architecture](imgs/monolith-architecture.png)

As the project grows in size and complexity, this simple folder-based organization causes significant problems:
1. **Uncontrolled File Growth**

    The number of files and folders balloons.

    It becomes impossible to find specific features quickly.

2. **Scattered UI Concerns**

    UI constructs are spread alphabetically across multiple folders.

    You might have Controllers, Views, ViewModels, Filters, and ModelBinders all in different top-level folders. They are not grouped by feature, making navigation tedious.

3. **Scattered Business Logic**

    Business rules are split between the Models folder and the Services folder.

    There is no explicit rule for which classes depend on which others.

4. **Spaghetti Code**

    Because the architecture lacks rigid boundaries at the project level, developers can easily create circular dependencies or mix responsibilities (e.g., putting database access logic directly inside a Controller).

    The lack of discipline leads to tightly coupled, fragile code.

## N-Layer
As applications grow, complexity becomes the biggest enemy. Layering is a strategy to manage this complexity.

The Core Idea:
You break the application into distinct parts based on their responsibilities or concerns. This follows the Separation of Concerns (SoC) principle.

- The Presentation Layer (UI) handles user interaction.
- The Business Logic Layer (BLL) handles the core rules.
- The Data Access Layer (DAL) handles database storage.

By organizing code this way, developers can quickly find where specific functionality is implemented, keeping the codebase tidy as it scales

There is a common confusion between these two terms:
| Concept | Definition                                                            | Example                                                                                                 |
| ------- | --------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- |
| Layer   | A logical separation of code within the application.                  | UI Project, BLL Project, DAL Project (all running on the same server).                                  |
| Tier    | A physical separation of deployment (different servers or processes). | The UI runs on one server, the Business Logic runs on another server, and the Database runs on a third. |

> Note: It is perfectly possible—and very common—to have an N-Layer application that is deployed to a single Tier (everything runs on one physical box).

![N-Layer Application Layers](imgs/n-layer-application-layers.png)

While this architecture is simple and intuitive, it has a significant disadvantage when implemented rigidly.

The Problem: Direction of Dependencies (Top-Down)
- The UI compiles against the BLL.
- The BLL compiles against the DAL.

Because the BLL depends on the DAL, your core business logic becomes dependent on the specific database implementation details (like Entity Framework classes or SQL connection strings).

The Consequence:
To test your business logic, you are forced to have a test database set up. This makes tests slow, brittle, and complicated to configure.

> This violates the Dependency Inversion Principle (DIP) we discussed earlier. The high-level module (BLL) is depending on the low-level module (DAL), rather than an abstraction.

(The next section of the chapter usually introduces Clean Architecture to fix this exact flaw, by making the DAL depend on the BLL via interfaces).

![N-layer Architecture](imgs/n-layer-architecture.png)

# Clean

**The Core Idea**:
Clean Architecture is an architectural pattern that places your business logic and application model at the very center of your application.

**What it solves**:
In traditional N-Layer architecture, the UI depends on the Business Logic, which depends on the Data Access Layer (Top-Down). Clean Architecture inverts this. Infrastructure (database, file system, external APIs) depends on the Core, not the other way around.

**Aliases (Same Concept, Different Names)**:
This architecture has been known by several names over the years, all referring to the same structural philosophy:
- Hexagonal Architecture (Alistair Cockburn)
- Ports and Adapters
- Onion Architecture (Jeffrey Palermo)
- Clean Architecture (Robert C. Martin)

> For this ebook, we refer to it as Clean Architecture.

The fundamental rule of Clean Architecture is the inversion of dependencies.
- The Traditional Way: Business Logic depends on the Database (BLL → DAL).
- The Clean Way: The Database (Infrastructure) depends on the Business Logic's interfaces (Infrastructure → IOrderRepository ← Application Core).

How it works:
1. You define abstractions (interfaces) inside the Application Core (e.g., IOrderRepository).
2. You implement these interfaces in the Infrastructure Layer (e.g., SqlOrderRepository).
3. The UI and Infrastructure reference the Application Core, but never reference each other's concrete types directly.

Visualizing the Architecture:

1. The "Onion" View (Concentric Circles)
   
    Clean Architecture is often visualized as a series of concentric circles.
    - Center (Core): Entities and Domain Interfaces. These have zero external dependencies.
    - Outer Layers: Domain Services, UI, Infrastructure.

    The Golden Rule: Dependencies flow inward toward the center. The inner circle knows nothing about the outer circles.

    ![Clean Architecture Onion View](imgs/clean-architecture-onion-view.png)

2. The Horizontal Layer View
   
   Understanding the Arrows:

   1. Solid Arrows (Compile-time): The UI references the Application Core. Infrastructure references the Application Core.

   2. Dashed Arrow (Runtime): The UI loads the Infrastructure assemblies at startup (via Dependency Injection) to fulfill the interfaces defined in the Core, but the UI code doesn't directly reference Infrastructure types in its business logic.

   ![Clean Architecture Horizontal View](imgs/clean-architecture-horizontal-view.png)

ASP.NET Core Architecture using clean architecture
![Architecture Diagram Following Clean Way](imgs/architecture-diagram-clean-way.png)

Why Use Clean Architecture? (The Benefits)
1. Superior Testability (Unit Testing)

    Because the Application Core has zero dependencies on the database or external frameworks, writing automated unit tests for this layer is incredibly easy.

    You can test business logic in isolation (Figure 5-10) without mocking a database.

    ![Clean Architecture Unit Tests](imgs/clean-architecture-unit-tests.png)

2. Easy "Swap-ability"

    Since the UI depends only on abstractions (interfaces), you can swap out Infrastructure implementations effortlessly.

    Need to change from SQL Server to CosmosDB? Create a new Infrastructure project implementing the same Core interfaces.

    This also facilitates Integration Testing (Figure 5-11), where you can swap in a Test Database or a Test API.

    ![Clean Architecture Integration Tests](imgs/clean-architecture-integration-tests.png)

3. Framework Independence

    Your business logic isn't tied to Entity Framework, ASP.NET, or any third-party library. You could theoretically re-platform the UI (e.g., from MVC to Blazor) without touching the Core logic.

Project Breakdown: Where Does Code Live?

In a Clean Architecture solution, the code is split across (at least) three main projects. Each project has distinct responsibilities and distinct types that belong in them.

1. Application Core (The Center)
   
   **Role**: Contains the Business Model and Application Logic. Has zero external dependencies (no EF Core, no System.Configuration).

    **What goes here (Types)**:

    - **Entities**: Business model classes that are persisted (e.g., Order, Product). Must be Persistence-Ignorant POCOs.
    - **Aggregates**: Groups of related entities treated as a single unit.
    - **Interfaces**: Abstractions for infrastructure operations (e.g., IOrderRepository, IEmailSender).
    - **Domain Services**: Complex business logic that doesn't naturally - fit inside a single entity.
    - **Specifications**: Query specifications (e.g., OrdersOverdueSpec).
    **Custom Exceptions & Guard Clauses**: Domain-specific exceptions.
    - **Domain Events & Handlers**: Events triggered by business rules (e.g., OrderCreatedEvent).
    - **DTOs**: Simple Data Transfer Objects used only internally within the Core (with no UI dependencies).

2. Infrastructure (The Implementation)
   
   **Role**: Implements the interfaces defined in the Application Core. Handles all data access and external communication.

    **What goes here**:

    - **EF Core Types**: DbContext, Migration files, and Entity Configurations (Fluent API).
    - **Data Access Implementation**: Repository classes that implement IOrderRepository (using EF Core, Dapper, etc.).
    - **Infrastructure Services**: Specific external service implementations, such as FileLogger (implements ILogger), SmtpNotifier (implements INotifier), or AzureBlobStorage (implements IFileStorage).
    
    > Dependency: The Infrastructure project must reference the Application Core project.

3. UI Layer (The Entry Point)
   
   **Role**: The web application entry point. Handles HTTP requests, routing, and UI rendering. Should not contain business logic.

    **What goes here**:
    - **Controllers**: API endpoints or MVC Controllers.
    - **Custom Filters**: Action/Exception filters.
    - **Custom Middleware**: Request pipeline components.
    - **Views & ViewModels**: Razor views and Presentation-specific ViewModels.
    - **Startup / Program.cs**: The Composition Root.

    The UI Layer must reference the Application Core project.
However, it should not directly instantiate or use static calls to Infrastructure types in its Controllers or Views. Controllers should only depend on interfaces from the Application Core.

> See repo: [eShopOnWeb Github Repo](https://github.com/dotnet-architecture/eShopOnWeb/tree/main) for reference

Comparison between N-Layer and Clean
| Feature                         | N-Layer (Traditional)                                                                                                         | Clean Architecture                                                                                                                            |
| ------------------------------- | ----------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------- |
| Dependency Flow                 | Top-Down: UI → BLL → DAL. High-level depends on low-level.                                                                    | Inward: UI → Core ← Infrastructure. Everything depends on the business core.                                                                  |
| Where does Business Logic live? | BLL (Business Logic Layer). It sits in the middle.                                                                            | Application Core. It sits at the very center (the "heart").                                                                                   |
| Database Coupling               | Tightly Coupled. The BLL references the DAL directly, so your business logic knows about SQL, EF Core, and tables.            | Completely Decoupled. The Core defines interfaces (e.g., IOrderRepository). It has zero knowledge of SQL or EF Core.                          |
| Project References              | UI → BLL → DAL. (DAL has no reference to UI).                                                                                 | UI → Core & Infrastructure → Core. (Infrastructure references Core; Core references nothing).                                                 |
| Testability                     | Hard / Slow. To test the BLL, you must initialize the DAL and the database, making unit tests slow and brittle.               | Easy / Fast. To test the Core, you just mock the interfaces and run pure logic. No database required.                                         |
| Swapping a Database             | Risky. Because the BLL references the DAL directly, changing from SQL to MongoDB often forces you to rewrite code in the BLL. | Simple. Create a new MongoOrderRepository that implements IOrderRepository. Swap it in the composition root (Startup). The Core doesn't care. |
| Framework Dependency            | Framework-Aware. The BLL often imports Entity Framework, Configuration, or other NuGet packages.                              | Framework-Ignorant (POCOs). The Core only uses plain C# classes and standard interfaces. It doesn't import EF, ASP.NET, or HTTP packages.     |
| Complexity                      | Low. Easy to understand and set up. Great for simple CRUD.                                                                    | High. More projects, more interfaces, and explicit dependency injection. Requires more upfront work.                                          |

> In N-Layer, your Business Logic depends on the Database.

> In Clean Architecture, the Database depends on the Business Logic.

# Vertical Slice
> Not mentioned in the book.

Vertical Slice Architecture groups code by feature or use case, not by technical class type. Instead of locating one “create order” feature across `Controllers`, `Services`, `Repositories`, and `DTOs`, keep its relevant code together.

```
Store.Api
├── Features
│   ├── Orders
│   │   ├── Create
│   │   │   ├── Endpoint.cs
│   │   │   ├── Request.cs
│   │   │   ├── Response.cs
│   │   │   ├── Command.cs
│   │   │   ├── Handler.cs
│   │   │   └── Validator.cs
│   │   ├── GetById
│   │   │   ├── Endpoint.cs
│   │   │   ├── Query.cs
│   │   │   └── Handler.cs
│   │   └── Cancel
│   └── Products
│       ├── Create
│       └── Search
├── Infrastructure
└── Program.cs
```

A vertical slice owns one complete behavior:

```
POST /orders
→ CreateOrder endpoint
→ CreateOrder command
→ CreateOrder handler
→ Validation
→ Database action
→ Response
```

This makes feature work faster because changes are local. The structure is especially useful with CQRS, which separates write operations from read operations: commands change state, while queries return information without changing state.

Commands and queries
```
Commands
├── CreateOrder
├── CancelOrder
└── ConfirmPayment

Queries
├── GetOrderById
├── SearchProducts
└── GetCustomerOrders
```

A command typically returns a small result, such as an identifier or success/failure. A query returns a read model optimized for the client.

Vertical slice architecture with different design patterns and architectures:
1. Vertical slices with Clean Architecture
   
   ```
    Store.Domain
    Store.Application
    └── Features
        └── Orders
            └── CreateOrder
    Store.Infrastructure
    Store.Api
   ```
2. Vertical slices with a mediator
   
   ```
    Endpoint → ISender.Send(command) → Handler
   ```

   A mediator helps keep endpoints thin and can centralize validation, logging, authorization, and transaction behavior. It is useful, but not mandatory: direct calls are often clearer for smaller systems.

Strengths
- High cohesion: files that change together are together.
- Easier navigation as features grow.
- Encourages small, focused handlers.
- Works naturally with CQRS and Minimal APIs.
- Reduces giant service classes.

Weaknesses
- Shared code must be carefully placed in a Common or shared-kernel area.
- Teams sometimes duplicate similar logic without recognizing a reusable domain concept.
- A feature folder alone does not guarantee good business boundaries.

> See repo: [Vertical Slice Example Github Repo](https://github.com/jeangatto/ASP.NET-Core-Vertical-Slice-Architecture/tree/main) for reference

# Modular Monolith
# Info
- Book: **Designing Data-Intensive Applications**
- Started Reading: **05/10/2025**
- Book cover:
  
  ![book-cover](./imgs/book-cover.png)

# Table of Contents
- [Info](#info)
- [Table of Contents](#table-of-contents)
- [Back Matter](#back-matter)
- [Objectives](#objectives)
- [People thoughts on the book](#people-thoughts-on-the-book)
  - [Jay Kreps - Creator of Apache Kafka and CEO of Confluent](#jay-kreps---creator-of-apache-kafka-and-ceo-of-confluent)
  - [Kevin Scott - CTO at Microsoft](#kevin-scott---cto-at-microsoft)
- [Preface](#preface)
- [Part 1: Foundations of Data Systems](#part-1-foundations-of-data-systems)
  - [Chapter 1: Reliable, Scalable, and Maintainable Applications](#chapter-1-reliable-scalable-and-maintainable-applications)
    - [Reliability](#reliability)
    - [Scalability](#scalability)
    - [Maintainability](#maintainability)
    - [Summary](#summary)
  - [Chapter 2: Data Models and Query Languages](#chapter-2-data-models-and-query-languages)
    - [Types of data models discussed:](#types-of-data-models-discussed)
    - [Relational Model](#relational-model)
    - [Document model](#document-model)
    - [Relational vs Document model (SQL vs NoSQL)](#relational-vs-document-model-sql-vs-nosql)
    - [The network model](#the-network-model)
    - [Query languages for data](#query-languages-for-data)
    - [Graph model](#graph-model)
    - [Difference between Graph and Network models](#difference-between-graph-and-network-models)
    - [Summary:](#summary-1)
    - [Takeway:](#takeway)
  - [Chapter 3: Storage and Retrieval](#chapter-3-storage-and-retrieval)


# Back Matter
Data is at the center of many challanges in system design today. Difficult issues need to be figured out, such as scalability, consistency, reliability, efficiency, and maintainability. In addition, we have an overwhelming variety of tools. including relational databases, NoSQL datastores, stream or batch processors, and message brokers. 
> What are the right choices for your application?

> How do you make sense of all these buzzwords.

In this practical and comprehensive guide, author Martin Kleppmann helps you navigate this diverse landscape by examining the pros and cons of various technologies for processing and storing data. Software keeps changing, but the fundamental principles remain the same. With this book, **software engineers** and **architects** will learn how to apply those ideas in practice, and how to make full use of data in modern applications.

# Objectives
- Peer under the hood of the systems you already use, and learn how to use and operate them more effectively
- Make informed decisions by identifying the strengths and weaknesses of different tools
- Navigate the trade-offs around consistency, scalability, fault tolerance, and complexity
- Understand the distributed systems research upon which modern databases are built
- Peek behind the scenes of major online services, and learn from their architectures.

# People thoughts on the book
## Jay Kreps - Creator of Apache Kafka and CEO of Confluent
   > "This book is awesome. it bridges the huge gap between distributed systems theory and practical engineering. I wish it had existed a decade ago, so I could have read it then and saved myself all the mistakes along the way."
## Kevin Scott - CTO at Microsoft
> "This book should be required reading for software engineers. Designing Data-Intensive Applications is a rare resource that connects theory and practice to help developers make smart decisions as they design and implement data infrastructure and systems"

# Preface
- We can call an application **data-intensive** if data is its primary challenge:
  - The quantity of data
  - The complexity of data
  - The speed at which its is changing
  
  as opposed to **compute-intensive**, where CPU cycles are the bottleneck.
- Book's purpose: Behind the rapid changes in technology, there are enduring principles that remain true, no matter which version of a particular tool you are using. If you understand those principles, you're in a position to see where each tool fits in, how to make good use of it, and how to avoid its pitfalls. That's where this book comes in.
- Goal: is to help you navigate the diverse and fast-changing landscape of technologies for processing and storing data.
- Outcome:
  - You will be in a great position to decide which kind of technology is appropriate for which purpose
  - To understand how tools can be combined to form the foundation of a good application architecture
  - Develop a good intuition for what your systems are doing under the hood so that you can reason about their behavior
- Audience: If any of the following are true for you, you'll find this book valuable
  - You want to learn how to make data systems scalable, for example, to support web or mobile apps with millions of users.
  - You need to make applications highly available (minimizing downtime) and operationally robust
  - You are looking for ways of making systems easier to maintain in the long run, even as they grow and as requirements and technologies change.
  - You have a natural curiousty  for the way things work and want to know what goes on inside major websites and online services. This book breaks down the internals of various databases and data processing systems, and it's great fun to explore the bright thinking that went into their design.

# Part 1: Foundations of Data Systems
The first four chapters go through the fundamental ideas that apply to all data systems, weather running on a single machine or distributed across a cluster of machines:
1. Chapter 1 introduces the terminology and approach that  we're going to use throughout this book. It examines what we actually mean by works like reliability, scalability, and maintainability, and how we can try to achieve these goals.
2. Chapter2 compares several different data models and query languages -- the most visible distinguishing factor between databases from a developer's point of view. We will see how different models are appropriate to different situations.
3. Chapter3 turns to the internals of storage engines and looks at how databases lay out data on disk. Different storage engines are optimized for different workloads, and choosing the right one can have a huge effect on performance.
4. Chapter 4 compares various formats for data encoding (serialization) and especially examines how they fare in an environment where application requirements change and schemas need to adapt over time

Later, PART 2 will turn to the particular issues of distributed data systems.

## Chapter 1: Reliable, Scalable, and Maintainable Applications
A data-intensive application is typically built from standard building blocks that provide commonly needed functionality. For example, many application need to:
- Store data so that they, or another application, can find it again later (databases)
- Remember the result of an expensive operation, to speed up reads (caches)
- Allow users to search data by keywords or filter it in various ways (search indexes)
- Send a message to another process, to be handled asynchronously (stream processing)
- Periodically crunch a large amount of accumulated data (batch processing)

![building-blocks](./imgs/building-blocks-01.png)

If you are designing a data system or service, a lot of tricky questions arise.
- How do you ensure that the data remains correct and complete, even when things go wrong internally?
- How do you provide consistently good performance to the clients, even when parts of your systems are degraded?
- How do you scale to handle an increase in load?
- What does a good API for the service look like?

### Reliability
Typical expectations include:
- The application performs the function that the user expected.
- It can tolerate the user making mistakes or using the software in unexpected ways.
- Its performance is good enough for the required use case, under the expected load and data volume.
- The system prevents any unauthorized access and abuse

If all those things together mean "working correctly", then we can understand reliability as meaning, roughly, "continuing to work correctly, even when things go wrong"

The things that can go wrong are called **faults**, and systems that anticipate faults and can cope with them are called fault-tolerant or resilient. It only makes sense to talk about tolerating certain types of faults.

A **fault** is usually defined as one component of the system deviating from its spec, whereas a **failure** is when the system as a whole stops.

One study of large internet services found that configuration errors by operators were the leading cause of outages, whereas hardware faults (servers or network) played a role in only 10-25% of outages

How important Is Reliability?

Bugs in business applications cause lost productivity, legal risks, and lost revenue.

Consider a parent who stores all their pictures and videos of their children in your photo application. How would they feel if that database was suddenly corrupted? Would they know how to restore if from a backup?

There are situations in which we may choose to sacrifice reliability in order to reduce development cost (e.g., when developing a prototype product for an unproven market) or operational cost (e.g., for a service with a very narrow profit margin) -- but we should be very conscious of when we are cutting corners.

### Scalability

Scalability means considering questions like
- If the system grows in a particular way, what are out options for coping with the growth?
- How can we add computing resources to handle the additional load?

Load can be described with a few numbers which we call load parameters. The best choice of parameters depends on the architecture of your system: it may be:
- requests per second to a web server
- the ratio of reads to writes in a database
- the number of simultaneously active users in a chat room
- the hit rate on a cache

To make this idea more concrete, let's consider Twitter as an example, using data published in November 2012. Two of the twitter's main operations are:
- Post tweet
  
  A user can publish a new message to their follower (4.6k requests/sec on average, over 12k requests/sec at peak).
- Home timeline
  
  A user can view tweets posted by the people they follow (300k requests/sec)

Simply handling 12k write per second (the peak rate for posting tweets) would be fairly easy. However, Twitter's scaling challenge is not primarily due to tweet volume, but due to fan-out (each user follows many people, and each user is followed by many people)

There are broadly two ways of implementing these two operations:

1. Posting a tweet simply inserts the new tweet into a global collection of tweets. When a user requests their home timeline, look up all the people they follow, find all the tweets for each of those users, and merge them (sorted by time). In a relational database like in the following image, you could write a query such as:

```sql
SELECT tweets.*, users.* FROM tweets
    JOIN users ON tweets.sender_id = users.id
    JOIN follows ON follow.followee_id = users_id
    WHERE follow.follower_id = current_user
```

![Write Operation On Relational Database](./imgs/twitter-simple-write-operation.png)

2. Matintain a cache for each user's home timeline -- like a mailbox of tweets for each recipient user. When a user posts a tweet, look up all the people who follow that user, and insert the new tweet into each of their home timeline caches. The request to read the home timeline is then cheap, because its result has been computed ahead of time.

![Twitter FanOut write](./imgs/twitter-fan-out.png)

The first version of Twitter used approach 1, but the systems struggled to keep up the the load of home timeline queries, so the company switched to approach 2. This works better because the average rate of published tweets is almost two orders of magnitude lower than the trate of home timeline reads, and so in this case it's preferable to do more work at write time and less at read time.

However, the downside of approach 2 is that posting a tweet now requires a lot of extra work. On average, a tweet is delivered to about 75 follower, so 4.7k tweets per second becomes 345k writes per second to the home time caches. But this average hides the fact that the number of followers per user varies wildly, and some user have over 30 million followers. This means that a single tweet may result in over 30 million writes to home timelines! Doing this in a timely manner -- Twitter tries to deliver tweets to followers within five seconds -- is a significant challenge.

In the example of Twitter, the distribution of followers per user (maybe weighted by how often those users tweet) is a key load parameter for discussing scalability, since it determines the fan-out load. Your application may have very different characteristics, but you can apply similar principles to reasoning about its load.

The final twist of the Twitter anecdote: now that approach 2 is robustly implemented, Twitter is moving to a hybrid of both approaches. Most users' tweets continue to be fanned out to home timelines at the time when they are posted, but a small number of users with a very large number of followers (i.e., celebrities) are excepted from this fan-out. Tweets from any celebrities that a user may follow are fetches separately and merged the user's home timeline when it's read. like in approach 1 (imo, to not have big uptime for celebrities and not to decrease customer satisfaction).

This hybrid approach is able to deliver consistently good performance. We will revisit this in chapter 12 after we have covered some more technical ground.

When you increase a load parameter and keep the system resources (CPU, memory, network bandwidth, etc.) unchanged, how is the performance of your system affected?

When you increase a load parameter, how much do you need to increase the resources if you want to keep performance unchanged?

Both questions require performance numbers, so let's look briefly at describing the performance of a system

The response time is what the client sees: besides the actual time to process the request (the service time), it includes network delays and queueing delays.

Latency is the duration that a request is waiting to be handled

High percentiles of response times, also known as tail latencies, are important because they directly affect users' experience of the service.
For example, Amazon describes response time requirements for internal services in the terms of the 99.9th percentile, even though it only affects 1 in 1,000 requests.

This is because the customers with the slowest requests are often those who have the most data on their accounts because they have made many purchases - that is, they're the most valuable customers.
It's important to keep those customers happy by ensuring the website is fast for them: Amazon has also observed that 100 ms increase in response time reduces sales by 1%, and others report that a 1-second slowdown reduces a customer satisfaction metric by 16%

On the other hand, optimizing the 99.99th percentile (the slowest 1 in 10,00 requests) was deemed too expensive and to not yield enough benefit for Amazon's purposes.

Reducing response times at very hight percentiles is difficult because they are easily affected by random events outside of your control, and the benefits are diminishing.
For example, percentiles are often used in service level objectives (SLOs) and service level agreements (SLAs) contracts that define the expected performance and availability of a service.

An SLA may state that the service is considered to be up if it has a median response time of less than 200 ms and a 99th percentile under 1 s(if the response time is longer, it might as well be down), and the service may be required to be up at least 99.9% of the time.

These metrics set expectations for clients of the service and allow customers to demand a refund if the SLA is not met.

![It takes one slow backend call to slow the others](./imgs/one-needed-backend-call-to-slow-others.png)

Some systems are elastic, meaning that they can automatically add computing resources when they detect a load increase, whereas other systems are scaled manually (a human analyzes the capacity and decides to add more machines to the system).

An elastic system can be useful if load is highly unpredictable, but manually scaled systems are simple and may have fewer operational surprises.

Common wisdom until recently was to keep your database on a single node (scale up) until scaling cost or high availability requirements forced you to make it distributed.

The architecture of systems that operate at large scale is usually highly specific to the application - there is no such thing as generic, one size-fits-all scalable architecture (informally known as magic scaling sauce). The problem may be the volume of reads, the volume of writes, the volume of data to store, the complexity of the data, the response time requirements, the access patterns, or (usually) some mixture of all of these plus many more issues.

For example, a system that is designed to handle 100,000 requests per second, each 1 kB in size, looks very different from a system that is designed for 3 requests per minute, each 2 GB in size - even though the two systems have the same data throughput

### Maintainability

It's well known that the majority of the cost of software is not in its initial development, but in its ongoing maintenance - fixing bugs, keeping its systems operational, investigating failures, adapting it to new platforms, modifying it for new use cases, repaying technical debt , and adding new features.

We can and should design software in such a way that is hopefully minimize pain during maintenance, and thus avoid creating legacy software ourselves.

To this end, we will pay particular attention to three design principles for software systems:

1. Operability

   Make it easy for operations teams to keep the system running smoothly

2. Simplicity
   
   Make it easy for new engineers to understand the system, by removing as much complexity as possible from the system. (not this is not the same as simplicity of the user interface.)

3. Evolvability

   Make it easy for engineers to make changes to the system in the future, adapting it for unanticipated use cases as requirements change. Also known as extensibility, modifiability, or plasticity.

Good operability means making routine tasks easy.

Most discussions of these Agile techniques focus on a fairly small, local scale (a couple of source code files within the same application). 

In this book, we search for ways
of increasing agility on the level of a larger data system, perhaps consisting of several different applications or services with different characteristics. 

For example, howwould you “refactor” Twitter’s architecture for assembling home timelines (“Describ
ing Load” on page 11) from approach 1 to approach 2?

### Summary

In this chapter, we have explored some fundamental ways of thinking about data intensive applications. 

These principles will guide us through the rest of the book,
where we dive into deep technical detail.

An application has to meet various requirements in order to be useful. There are functional requirements (what it should do, such as allowing data to be stored, retrieved, searched, and processed in various ways), and some nonfunctional requirements (general properties like security, reliability, compliance, scalability, compatibility, and maintainability). In this chapter we discussed reliability, scalability, and maintainability in detail.

- Reliability means making systems work correctly, even when faults occur. Faults can be in hardware (typically random and uncorrelated), software (bugs are typically systematic and hard to deal with), and humans (who inevitably make mistakes from time to time). Fault-tolerance techniques can hide certain types of faults from the end user.

- Scalability means having strategies for keeping performance good, even when load increases. In order to discuss scalability, we first need ways of describing load and performance quantitatively. We briefly looked at Twitter’s home timelines as an example of describing load, and response time percentiles as a way of measuring performance. In a scalable system, you can add processing capacity in order to remain reliable under high load.
  
- Maintainability has many facets, but in essence it’s about making life better for the engineering and operations teams who need to work with the system. Good abstrac tions can help reduce complexity and make the system easier to modify and adapt for new use cases. Good operability means having good visibility into the system’s health, and having effective ways of managing it.

There is unfortunately no easy fix for making applications reliable, scalable, or maintainable. However, there are certain patterns and techniques that keep reappearing in different kinds of applications. 

In the next few chapters we will take a look at some examples of data systems and analyze how they work toward those goals.

## Chapter 2: Data Models and Query Languages
How storage engines work; thatis, how these data models are actually implemented.

### Types of data models discussed:
1. Hierarchical model
2. Network model
3. Relational model
4. Document model
5. Graph model
6. Others mentioned e.g. Vector model

### Relational Model
Query language: SQL

Over the years, there have been many competing approaches to data storage and querying. In the 1970s and early 1980s, the **network** model and the **hierarchical** model were the main alternatives, but the relational model came to dominate them. Object databases came and went again in the late 1980s and early 1990s. XML databases appeared in the early 2000s, but have only seen niche adoption. Each competitor to the relational model generated a lot of hype in its time, but it never lasted.

As computer became vastly more powerful and networked, they started being used for increasingly diverse purposes. And remarkably, relational databases turned out to generalize very well, beyond their original scope of business data processing, to a broad variety of use cases. Much of what you see on the web today is still powered by relational databases, be it online publishing, discussion, social networking, e-commerce games, software-as-a-service productivity applications, or much more.

![Relational model's representation](imgs/relational-model-representation.png)

### Document model
Query language: MQL (MongoDB Query Language) or MapReduce

Now, in the 2010s, NoSQL is the latest attempt to overthrow the relational model’s dominance. The name “NoSQL” is unfortunate, since it doesn’t actually refer to any particular technology—it was originally intended simply as a catchy Twitter hashtag for a meetup on open source, distributed, nonrelational databases in 2009. 

Nevertheless, the term struck a nerve and quickly spread through the web startup community and beyond. A number of interesting database systems are now associated withthe #NoSQL hashtag, and it has been retroactively reinterpreted as Not Only SQL.

There are several driving forces behind the adoption of NoSQL databases, including:

- A need for greater scalability than relational databases can easily achieve, includ
ing very large datasets or very high write throughput
- A widespread preference for free and open source software over commercial
database products
- Specialized query operations that are not well supported by the relational model
- Frustration with the restrictiveness of relational schemas, and a desire for a more dynamic and expressive data model
  
Different applications have different requirements, and the best choice of technology
for one use case may well be different from the best choice for another use case. It
therefore seems likely that in the foreseeable future, relational databases will continue
to be used alongside a broad variety of nonrelational datastores—an idea that is
sometimes called polyglot persistence.

__Document model representation__
```json
{
  "user_id":     251,
  "first_name":  "Bill",
  "last_name":   "Gates",
  "summary":     "Co-chair of the Bill & Melinda Gates... Active blogger.",
  "region_id":   "us:91",
  "industry_id": 131,
  "photo_url":   "/p/7/000/253/05b/308dd6e.jpg",
  "positions": [
    {"job_title": "Co-chair", "organization": "Bill & Melinda Gates Foundation"},
    {"job_title": "Co-founder, Chairman", "organization": "Microsoft"}
  ],
  "education": [
    {"school_name": "Harvard University",       
    "start": 1973, "end": 1975},
    {"school_name": "Lakeside School, Seattle", "start": null, "end": null}
  ],
  "contact_info": {
    "blog":    
    "http://thegatesnotes.com",
    "twitter": "http://twitter.com/BillGates"
  }
}
```

![Document model representation](imgs/document-model-representation.png)

Some developers feel that the JSON model reduces the impedance mismatch between the application code and the storage layer. However, as we shall see in Chapter 4, there are also problems with JSON as a data encoding format. The lack of a schema is often cited as an advantage; we will discuss this in “Schema flexibility in the document model” on page 39.

The JSON representation has better locality than the multi-table schema in Figure 2-1. If you want to fetch a profile in the relational example, you need to either perform multiple queries (query each table by user_id) or perform a messy multi way join between the users table and its subordinate tables. In the JSON representation, all the relevant information is in one place, and one query is sufficient.

The one-to-many relationships from the user profile to the user’s positions, educational history, and contact information imply a tree structure in the data, and the JSON representation makes this tree structure explicit (see Figure 2-2).

> Normalization is they idea of removing duplication, and using GUID is a way to achieve that.

In document databases, joins are not needed for one-to-many tree structures, and support for joins is often weak.

> the lists of regions and industries are probably small and slow-changing enough that the application can simply keep them in memory.

> **Data integrity** means that data should remain accurate, consistent, valid, and trustworthy through it's cycle

It's often described as schemaless, but that's misleading as the that reads the data usually assumes some kind of structure, ther is an implict schema, but its not enforced by the database. A more accurate term is schema-on-read

- Implicit is schema-on-read similar to dynamic runtime
- Explicit is schema-on-write similar to compile time

### Relational vs Document model (SQL vs NoSQL)
Which data model leads to simpler application code?

- If the data in your application has a document-like structure (i.e., a tree of one-to-many relationships, where typically the entire tree is loaded at once), then it’s probably a good idea to use a document model. The relational technique of shredding—splitting a document-like structure into multiple tables (like positions, education, and contact_info in Figure 2-1)—can lead to cumbersome schemas and unnecessarily complicated application code.
- The document model has limitations: for example, you cannot refer directly to a nested item within a document, but instead you need to say something like “the second item in the list of positions for user 251” (much like an access path in the hierarchical model). However, as long as documents are not too deeply nested, that is not usually a problem.
- The poor support for joins in document databases may or may not be a problem, depending on the application. For example, many-to-many relationships may never be needed in an analytics application that uses a document database to record which events occurred at which time
- However, if your application does use many-to-many relationships, the document model becomes less appealing. It’s possible to reduce the need for joins by denormalizing, but then the application code needs to do additional work to keep the denormalized data consistent. Joins can be emulated in application code by making multiple requests to the database, but that also moves complexity into the application and is usually slower than a join performed by specialized code inside the database. In such cases, using a document model can lead to significantly more complex application code and worse performance
- It’s not possible to say in general which data model leads to simpler application code; it depends on the kinds of relationships that exist between data items. For highly interconnected data, the document model is awkward, the relational model is acceptable, and graph models (see “Graph-Like Data Models” on page 49) are the most natural.

The difference between the approaches is particularly noticeable in situations where an application wants to change the format of its data. 

For example, say you are currently storing each user’s full name in one field, and you instead want to store the first name and last name separately [23]. In a document database, you would just start writing new documents with the new fields and have code in the application that handles the case when old documents are read. For example:

```json
  if (user && user.name && !user.first_name) {
  // Documents written before Dec 8, 2013 don't have first_name
    user.first_name = user.name.split(" ")[0];
  }
```

On the other hand, in a “statically typed” database schema, you would typically per form a migration along the lines of:

```SQL
  ALTER TABLE users ADD COLUMN first_name text;
  UPDATE users SET first_name = split_part(name, ' ', 1);      
  UPDATE users SET first_name = substring_index(name, ' ', 1);      -- PostgreSQL-- MySQL
```

### The network model
Query language: You tell the database the exact path (Access paths)

Document model is great for schemaless models but can only have one parent therefore, graph model was introduced, and the network model is an early version of it.

A record can have multiple parents.

![Many to many relationships](imgs/many-to-many-relationships.png)

### Query languages for data

1. Imperative
    1. Mostly used in programming languages
         ```javascript
           function getSharks() {
             var sharks = [];
             for (var i = 0; i < animals.length; i++) {
               if (animals[i].family === "Sharks") {
                 sharks.push(animals[i]);
               }
             }
             return sharks;
           }
         ```
    2. It's about how to achieve the goal
2. Declarative
    1. Like SQL or CSS
        ```SQL
          SELECT * FROM animals where family = 'Sharks';
        ```
        ```CSS
          li.selected > p {
            background-color: blue;
          }
        ```
        whereas in javascript, if I want to do the same CSS in Javascript, it would be like that:
        ```javascript
        var liElements = document.getElementsByTagName("li");
        for (var i = 0; i < liElements.length; i++) {
          if (liElements[i].className === "selected") {
            var children = liElements[i].childNodes;
            for (var j = 0; j < children.length; j++) {
              var child = children[j];
              if (child.nodeType === Node.ELEMENT_NODE && child.tagName === "P") {
                child.setAttribute("style", "background-color: blue");
              }
            }
          }
        }
        ```
        in a web browser, using declarative CSS styling is much better than manipulating styles imperatively in JavaScript. Similarly, in databases, declarative query languages like SQL turned out to be much better than imperative query APIs.
    2. You specify the pattern of the data you want - what conditions the results must meet, and how you want the data to be transformed (e.g. sorted, grouped, and aggregated - but not how to achieve that goal).
    3. It's up to the database system's **query optimizer** to decide which indexes and which join methods to use, and in which order to execute various parts of the query
    4. The fact that SQL is more limited in functionality gives the database much more room for automatic optimizations

### Graph model
Query language: Cypher, SparQL, and Datalog

- We saw earlier that many-to-many relationships are an important distinguishing feature between different data models. If your application has mostly one-to-many relationships (tree-structured data) or no relationships between records, the document model is appropriate.
- But what if many-to-many relationships are very common in your data? The relational model can handle simple cases of many-to-many relationships, but as the connections within your data become more complex, it becomes more natural to start modeling your data as a graph.
- A graph consists of two kinds of objects: vertices (also known as nodes or entities) and edges (also known as relationships or arcs). Many kinds of data can be modeled as a graph. Typical examples include:
  - **Social graphs**: Vertices are people, and edges indicate which people know each other.
  - **The web graph**: Vertices are web pages, and edges indicate HTML links to other pages.
  - **Road or rail networks**: Vertices are junctions, and edges represent the roads or railway lines between them.
- Well-known algorithms can operate on these graphs: for example, car navigation systems search for the shortest path between two points in a road network, and PageRank can be used on the web graph to determine the popularity of a web page and thus its ranking in search results.

![Graph model representation](imgs/graph-model-representation.png)

Two ways of structuring graph models:
  - Property graph
    - implemented by Neo4j, Titan, and InfiniteGraph
  - Triple-store graph
    - implemented by Datomic, AllegroGraph, and others

### Difference between Graph and Network models
Think of Network Model as the old-generation graph database and Graph Model as the modern version

![Difference between network and graph model](imgs/difference-between-network-and-graph-models.png)

Example: suppose you want to find Ali's friends
- Network Model:
  - Find Ali -> Follow Friend Link -> Get Friend Records
- Graph Model:
  - ```graph
    MATCH (a:Person {name:"Ali"})-[:FRIEND]->(f) 
    RETURN f
    ```
You specify the relationship pattern, and the database finds the path.

- Network Model = "How do I traverse?"
- Graph Model = "What relationships am I looking for?

Basically graph is schema-less and declarative

### Summary:
- Data models are a huge subject, and in this chapter we have taken a quick look at a broad variety of different models. We didn’t have space to go into all the details of each model, but hopefully the overview has been enough to whet your appetite to find out more about the model that best fits your application’s requirements.
- Historically, data started out being represented as one big tree (the hierarchical model), but that wasn’t good for representing many-to-many relationships, so the relational model was invented to solve that problem. More recently, developers found that some applications don’t fit well in the relational model either. New nonrelational “NoSQL” datastores have diverged in two main directions:
  - Document databases target use cases where data comes in self-contained docu
ments and relationships between one document and another are rare.
  - Graph databases go in the opposite direction, targeting use cases where anything is potentially related to everything.
- All three models (document, relational, and graph) are widely used today, and each is good in its respective domain. One model can be emulated in terms of another model. for example, graph data can be represented in a relational database—but the result is often awkward. That’s why we have different systems for different purposes, not a single one-size-fits-all solution.
- One thing that document and graph databases have in common is that they typically don’t enforce a schema for the data they store, which can make it easier to adapt applications to changing requirements. However, your application most likely still assumes that data has a certain structure; it’s just a question of whether the schema is explicit (enforced on write) or implicit (handled on read).
- Each data model comes with its own query language or framework, and we discussed several examples: SQL, MapReduce, MongoDB’s aggregation pipeline, Cypher, SPARQL, and Datalog. We also touched on CSS and XSL/XPath, which aren’t data base query languages but have interesting parallels.
- Although we have covered a lot of ground, there are still many data models left
unmentioned. To give just a few brief examples:
  - Specialized sequence databases (bioinformatics databases)
  - Specialized scientific/big-data processing systems
  - Information retrieval / **search index model** will be covered later.....

### Takeway:
- Relational databases are best when data is highly interconnected and requires joins.
- Document databases are best when data naturally forms self-contained hierarchical aggregates. 
- Graph databases are best when relationships themselves are the primary focus.
- Relational → Tables
- Document   → JSON Trees
- Hierarchical → Trees
- Network → Pointer Graphs
- Graph → Flexible Relationship Graphs

## Chapter 3: Storage and Retrieval
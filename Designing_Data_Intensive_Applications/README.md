# Info
- Book: **Designing Data-Intensive Applications**
- Started Reading: **05/10/2025**

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
  
  as opposed to **compute-intensive**, where CPU cycles are the bottlenech.
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

However, the downside of approach 2 is that posting a tweet now requires alot of extra work. On avreage, a tweet is delivered to about 75 follower, so 4.7k tweets per second becomes 345k writes per second to the home time caches. But this average hides the fact that the number of followers per user varies wildly, and some user have over 30 million followers. This means that a signle tweet may result in over 30 million writes to home timelines! Doing this in a timely manner -- Twitter tries to deliver tweets to followers within five seconds -- is a signifact challenge.

In the example of Twitter, the distribution of followers per user (maybe weighted by how often those users tweet) is a key load paramter for discussing scalability, since it determines the fan-out load. Your application may have very different characteristics, but you can apply similar principles to reasoning about its load.

The final twist of the Twitter anecote: now that approach 2 is robusly implemented, Twitter is moving to a hybrid of both approaches. Most users' tweets continue to be fanned out to home timelines at the time when they are posted, but a small number of users with a very large number of followers (i.e., celebrities) are excepted from this fan-out. Tweets from any celebrities that a user may follow are fetches seperately and merged the user's home timeline when it's read. like in approach 1 (imo, to not have big uptime for celebrities and not to decrease customer satisfaction).

This hybrid approach is able to deliver consistently good performance. We will revisit this in chapter 12 after we have covered some more technical ground.
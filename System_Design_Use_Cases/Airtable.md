# Table Of Contents
- [Table Of Contents](#table-of-contents)
- [References](#references)
- [Airtable - why it caps at 50K Rows](#airtable---why-it-caps-at-50k-rows)
  - [Dynamic Schema and Solution](#dynamic-schema-and-solution)
  - [MVCC Transactions](#mvcc-transactions)
  - [Takeaways:](#takeaways)

# References
- [Airtable - why it caps at 50K Rows](https://youtu.be/DI7P0LdVxRU)

# Airtable - why it caps at 50K Rows
## Dynamic Schema and Solution
Airtable lets you design db with dynamic schema as you go, types could be number/text/signature/etc..

Airtable uses a base model with a worker memory and each db is assigned to one worker

They call it in-memory database

In-memory database comes with problems of scaling, it needs to be tied to one machine capability.

Airtable uses incremental view maintenance, maintaining data view whenever a write comes with SignalR changes in real time.

Client website has in browser view copy.

Airtable has post-insert data events to recalculate relations, formulas, and analytics.

Airtable uses EAV model for dynamic schema.

Airtable uses functional indexing.

It uses one writer for concurrency and many readers.

## MVCC Transactions
Multi-Version Concurrency Control (MVCC) is a concurrency control mechanism used by database engines (such as PostgreSQL, Oracle, and SQL Server under specific isolation levels) to allow concurrent reads and writes without blocking each other.

The fundamental rule of MVCC is: Readers never block Writers, and Writers never block Readers.

In traditional multi-user database systems, concurrency was managed using Exclusive and Shared Locks (2-Phase Locking / 2PL):

- If Transaction A was updating a row, it placed an Exclusive (Write) Lock. Any read query (Transaction B) trying to fetch that row had to wait until Transaction A committed or rolled back.
- Under heavy traffic, read-heavy workloads (e.g., dashboard reporting) and write-heavy workloads (e.g., payment processing) would constantly block each other, causing connection thread pooling bottlenecks, high latency, and frequent deadlocks.

Instead of modifying data in place and locking the row, an MVCC engine treats updates as version creation. When a row is modified or deleted, the database retains the older version of the data alongside the new version

## Takeaways:
1. Keeping data in memory moves app from IO-Bound to CPU-Bound
2. Ship diffs, not re-runs of data (Based on write)
3. Fractional Indexing
4. Run old and new side by side until they match (rust and javascript in Airtable case)
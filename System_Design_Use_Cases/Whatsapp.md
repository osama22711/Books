# References:
1. [Hello Interview - Design Whatsapp: System Design Interview w/ a Ex-Meta Senior Manager](https://www.youtube.com/watch?v=cr6p0n0N-VA)

# Consistent Hashing
Consistent hashing is a technique for distributing keys—such as cache entries, database records, or requests—across multiple servers while minimizing reassignment when servers are added or removed. It is commonly used in distributed caches, sharded databases, and request routing.

A simple partitioning strategy is: `server = hash(key) mod N`

where N is the number of servers.


Consistent hashing places both servers and keys on a circular hash space called a hash ring:
1. Hash each server identifier and place it on the ring.
2. Hash each key and place it on the same ring.
3. Starting from the key’s position, move clockwise.
4. Assign the key to the first server encountered.

Example: Imagine a ring with three servers

```
             Server A
                |
       key X -> | clockwise
                |
Server C -------+------- Server B
```

If key X is located between Server C and Server A, it belongs to Server A—the next server clockwise.

Consistent hashing is useful for:
1. Distributed caches such as Redis or Memcached clusters.
2. Sharded databases and key-value stores.
3. CDN or edge-request routing.
4. WebSocket connection routing.
5. Distributed worker assignment.
6. Partitioning data among service instances.


# Redis Pub/Sub
Redis Pub/Sub is a lightweight messaging mechanism where publishers send messages to named channels, and all currently connected subscribers to those channels receive them. Publishers do not need to know who the subscribers are, which decouples the producing and consuming applications.

Redis recommends Pub/Sub for broadcasting real-time events such as:
1. Chat messages.
2. Live notifications.
3. Cache invalidation signals.
4. Presence updates.
5. UI or dashboard updates.
6. Broadcasting configuration changes.
7. Sending events to WebSocket servers.

Redis Pub/Sub is primarily a real-time notification mechanism. Kafka is a durable distributed event-streaming platform. The biggest difference is that Redis Pub/Sub forgets a message after delivering it, while Kafka stores events so consumers can process, replay, and recover them later.

Kafka stores records in partitioned topics, assigns records offsets, and allows consumers to resume from those offsets. Redis Pub/Sub instead delivers messages to currently connected subscribers and discards them; a disconnected subscriber permanently misses the message.

# Load balancer Level7 and Level4
A Layer 4 (L4) load balancer routes network connections using transport-level information such as IP addresses, ports, and TCP/UDP. A Layer 7 (L7) load balancer understands application protocols—usually HTTP—and can route individual requests based on paths, hosts, headers, cookies, and other request data.

- Level4 is usually used with websockets
- Level7 is used with HTTP protocol

# DynamoDB
Amazon DynamoDB is a fully managed, serverless NoSQL database from AWS designed for predictable low-latency reads and writes at large scale. It stores flexible items in tables and automatically manages much of the infrastructure, scaling, availability, and partitioning.

You would choose DynamoDB over SQL Server when your workload needs massive horizontal scale, predictable key-based access, automatic operations, and serverless elasticity more than relational querying and joins. DynamoDB is not generally “better” than SQL Server; it is optimized for a different class of problems.

1. **Automatic horizontal scaling**
   
   DynamoDB distributes data across partitions and can automatically scale throughput as traffic grows. Its on-demand mode removes most capacity planning and supports pay-per-request usage.
2. **Serverless operations**

   AWS describes DynamoDB as a serverless database with automatic scaling, built-in security, continuous backups, and multi-Region replication capabilities.
3. **Predictable low latency at high request volume**

   DynamoDB is designed for single-digit-millisecond reads and writes when the access pattern is designed around its keys.
4. **Very high traffic and availability requirements**

   DynamoDB is useful when the application may receive millions of simultaneous requests or traffic spikes that are difficult to predict. AWS positions it for workloads such as session stores and shopping carts that need high throughput and distributed processing.

SQL Server is usually the better choice when you need relational capabilities.
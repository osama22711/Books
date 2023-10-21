// See https://aka.ms/new-console-template for more information


using ChatApp;

IChatMediator chatMediator = new ChatMediator();

User alice = new User("Alice", chatMediator);
User bob = new User("Bob", chatMediator);
User yousef = new User("Yousef", chatMediator);

chatMediator.AddUser(alice);
chatMediator.AddUser(bob);
chatMediator.AddUser(yousef);

alice.Send("Hello, everyone!");
bob.Send("Hi, Alice!");
yousef.Send("I'm leaving...");
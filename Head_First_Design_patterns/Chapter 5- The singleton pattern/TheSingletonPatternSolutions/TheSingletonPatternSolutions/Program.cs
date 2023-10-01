// See https://aka.ms/new-console-template for more information

using TheSingletonPatternSolutions;

Console.WriteLine("------------------------");
Console.WriteLine("One Lazy Instance");
Console.WriteLine("------------------------");

var lazySingleton = LazySingletonInstance.GetInstance();
var lazySingleton2 = LazySingletonInstance.GetInstance();

if (lazySingleton == lazySingleton2)
{
    Console.WriteLine("Lazy initialized Singleton works!");
}
else
{
    Console.WriteLine("Lazy initialized Singleton doesn't work!");
}

Console.WriteLine("------------------------");
Console.WriteLine("One Eager Instance");
Console.WriteLine("------------------------");

var eagerSingleton = EagerSingletonInstance.GetInstance();
var eagerSingleton2 = EagerSingletonInstance.GetInstance();

if (eagerSingleton == eagerSingleton2)
{
    Console.WriteLine("Eager initialized Singleton works!");
}
else
{
    Console.WriteLine("Eager initialized Singleton doesn't work!");
}

Console.WriteLine("------------------------");
Console.WriteLine("One Thread safe lock Instance");
Console.WriteLine("------------------------");

var threadLockSingleton = ThreadLockSingletonInstance.GetInstance();
var threadLockSingleton2 = ThreadLockSingletonInstance.GetInstance();

if (threadLockSingleton == threadLockSingleton2)
{
    Console.WriteLine("ThreadLock initialized Singleton works!");
}
else
{
    Console.WriteLine("ThreadLock initialized Singleton doesn't work!");
}
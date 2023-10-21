// See https://aka.ms/new-console-template for more information


using NumberSorter.Handlers;

Handler handler1 = new ConcreteHandler1();
Handler handler2 = new ConcreteHandler2();
Handler handler3 = new ConcreteHandler3();


handler1.SetSuccessor(handler2);
handler2.SetSuccessor(handler3);

int[] requests = { 5, 15, 25, 35 };

foreach (int i in requests)
{
    handler1.HandleRequest(i);
}
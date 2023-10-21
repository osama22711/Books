namespace NumberSorter.Handlers
{
    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine($"Request {request} is handled by ConcreteHandler1");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}

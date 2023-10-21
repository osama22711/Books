namespace NumberSorter.Handlers
{
    public class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine($"Request {request} is handled by ConcreteHandler3");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}

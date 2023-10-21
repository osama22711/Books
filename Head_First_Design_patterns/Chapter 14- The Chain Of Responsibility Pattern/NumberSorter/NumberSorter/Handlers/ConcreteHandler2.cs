namespace NumberSorter.Handlers
{
    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine($"Request {request} is handled by ConcreteHandler2");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}

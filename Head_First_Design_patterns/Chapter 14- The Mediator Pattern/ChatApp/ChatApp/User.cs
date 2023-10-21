namespace ChatApp
{
    public class User
    {
        private string name { get; set; }
        private IChatMediator chatMediator { get; set; }

        public User(string name, IChatMediator chatMediator)
        {
            this.name = name;
            this.chatMediator = chatMediator;
        }

        public void Send(string message)
        {
            Console.WriteLine($"{name} sends: {message}");
            chatMediator.SendMessage(message, this);
        }

        public void Receive(string message)
        {
            Console.WriteLine($"{name} receives: {message}");
        }
    }
}

namespace ChatApp
{
    public interface IChatMediator
    {
        public void AddUser(User user);
        public void SendMessage(string message, User user);
    }
}

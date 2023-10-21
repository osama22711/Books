namespace ChatApp
{
    public class ChatMediator : IChatMediator
    {
        private List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void SendMessage(string message, User user)
        {
            foreach (var u in users)
            {
                if (u != user)
                {
                    u.Receive(message);
                }
            }
        }
    }
}

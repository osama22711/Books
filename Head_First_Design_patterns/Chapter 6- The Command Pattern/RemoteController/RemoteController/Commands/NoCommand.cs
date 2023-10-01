namespace RemoteController.Commands
{
    public class NoCommand : ICommand
    {
        public string Name { get; set; } = "No Command";

        public void Execute()
        {
            Console.WriteLine(Name);
        }

        public void Undo()
        {
            Console.WriteLine(Name);
        }
    }
}

namespace RemoteController.Commands
{
    public class MacroCommand : ICommand
    {
        private List<ICommand> commands;

        public string Name { get; set; }

        public MacroCommand(List<ICommand> commands)
        {
            this.commands = commands;
            Name = $"Party MODE commands!!!";
        }

        public void Execute()
        {
            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].Execute();
            }
        }

        public void Undo()
        {
            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].Undo();
            }
        }
    }
}

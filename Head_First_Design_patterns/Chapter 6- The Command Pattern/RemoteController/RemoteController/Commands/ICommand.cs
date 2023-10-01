// See https://aka.ms/new-console-template for more information

namespace RemoteController.Commands
{
    public interface ICommand
    {
        public string Name { get; set; }
        public void Execute();
        public void Undo();
    }
}
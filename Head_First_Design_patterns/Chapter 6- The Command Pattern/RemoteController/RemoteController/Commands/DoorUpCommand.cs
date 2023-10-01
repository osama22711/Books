// See https://aka.ms/new-console-template for more information

using RemoteController.Models;

namespace RemoteController.Commands
{
    public class DoorUpCommand : ICommand
    {
        public string Name { get; set; }
        private readonly Door garageDoor;

        public DoorUpCommand(Door garageDoor)
        {
            this.garageDoor = garageDoor;
            Name = $"Openning Door of {garageDoor.room} room command";
        }


        public void Execute()
        {
            garageDoor.Open();
        }

        public void Undo()
        {
            garageDoor.Close();
        }
    }
}
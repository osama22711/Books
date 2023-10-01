// See https://aka.ms/new-console-template for more information

using RemoteController.Models;

namespace RemoteController.Commands
{
    public class DoorDownCommand : ICommand
    {
        public string Name { get; set; }
        private readonly Door garageDoor;

        public DoorDownCommand(Door garageDoor)
        {
            this.garageDoor = garageDoor;
            Name = $"Closing Door of {garageDoor.room} room command";
        }


        public void Execute()
        {
            garageDoor.Close();
        }

        public void Undo()
        {
            garageDoor.Open();
        }
    }
}
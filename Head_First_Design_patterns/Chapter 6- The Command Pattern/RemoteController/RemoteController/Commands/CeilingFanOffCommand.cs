// See https://aka.ms/new-console-template for more information

using RemoteController.Models;

namespace RemoteController.Commands
{
    public class CeilingFanOffCommand : ICommand
    {
        public string Name { get; set; }
        private readonly CeilingFan ceilingFan;

        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
            Name = $"Turn Off Ceiling Fan of {ceilingFan.room} room command";
        }


        public void Execute()
        {
            ceilingFan.TurnOff();
        }

        public void Undo()
        {
            ceilingFan.TurnOnWithLowSpeed();
        }
    }
}
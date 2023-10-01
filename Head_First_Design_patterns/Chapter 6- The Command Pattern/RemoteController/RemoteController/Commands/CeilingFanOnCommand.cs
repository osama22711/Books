// See https://aka.ms/new-console-template for more information

using RemoteController.Models;

namespace RemoteController.Commands
{
    public class CeilingFanOnCommand : ICommand
    {
        public string Name { get; set; }
        private readonly CeilingFan ceilingFan;

        public CeilingFanOnCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
            Name = $"Turn On Ceiling Fan of {ceilingFan.room} room command";
        }


        public void Execute()
        {
            ceilingFan.TurnOnWithLowSpeed();
        }

        public void Undo()
        {
            ceilingFan.TurnOff();
        }
    }
}
// See https://aka.ms/new-console-template for more information

using RemoteController.Models;

namespace RemoteController.Commands
{
    public class LightOnCommand : ICommand
    {
        public string Name { get; set; }
        private readonly Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
            Name = $"Turn On Light Command Of {this.light.room}'s room";
        }

        public void Execute()
        {
            light.TurnOn();
        }

        public void Undo()
        {
            light.TurnOff();
        }
    }
}
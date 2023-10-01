// See https://aka.ms/new-console-template for more information

using RemoteController.Models;

namespace RemoteController.Commands
{
    public class LightOffCommand : ICommand
    {
        public string Name { get; set; }
        private readonly Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
            Name = $"Turn Off Light Command Of {this.light.room}'s room";
        }

        public void Execute()
        {
            light.TurnOff();
        }

        public void Undo()
        {
            light.TurnOn();
        }
    }
}
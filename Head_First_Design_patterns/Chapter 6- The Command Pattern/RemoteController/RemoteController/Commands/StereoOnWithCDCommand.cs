// See https://aka.ms/new-console-template for more information

using RemoteController.Models;

namespace RemoteController.Commands
{
    public class StereoOnWithCDCommand : ICommand
    {
        public string Name { get; set; }
        private readonly Stereo livingRoomStereo;

        public StereoOnWithCDCommand(Stereo livingRoomStereo)
        {
            this.livingRoomStereo = livingRoomStereo;
            Name = $"Turning On Stereo of {livingRoomStereo.room} room command";
        }


        public void Execute()
        {
            livingRoomStereo.SetCD();
            livingRoomStereo.TurnOn();
        }

        public void Undo()
        {
            livingRoomStereo.TurnOff();
        }
    }
}
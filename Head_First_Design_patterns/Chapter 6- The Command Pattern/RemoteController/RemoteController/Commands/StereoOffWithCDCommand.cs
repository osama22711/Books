// See https://aka.ms/new-console-template for more information

using RemoteController.Models;

namespace RemoteController.Commands
{
    public class StereoOffWithCDCommand : ICommand
    {
        public string Name { get; set; }
        private readonly Stereo livingRoomStereo;

        public StereoOffWithCDCommand(Stereo livingRoomStereo)
        {
            this.livingRoomStereo = livingRoomStereo;
            Name = $"Turning Off Stereo of {livingRoomStereo.room} room command";
        }


        public void Execute()
        {
            livingRoomStereo.TurnOff();
        }

        public void Undo()
        {
            livingRoomStereo.SetCD();
            livingRoomStereo.TurnOn();
        }
    }
}
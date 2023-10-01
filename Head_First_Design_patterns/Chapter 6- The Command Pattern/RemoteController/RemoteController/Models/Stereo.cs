namespace RemoteController.Models
{
    public class Stereo
    {
        public readonly RoomsEnum room;

        public Stereo(RoomsEnum room)
        {
            this.room = room;
        }

        public void TurnOn()
        {
            Console.WriteLine($"Turning On {room}'s stereo");
        }

        public void TurnOff()
        {
            Console.WriteLine($"Turning Off {room}'s stereo");
        }

        public void SetCD()
        {
            Console.WriteLine($"Setting CD on {room}'s stereo");
        }

        public void SetDvd()
        {
            Console.WriteLine($"Setting Dvd on {room}'s stereo");
        }

        public void SetRadio()
        {
            Console.WriteLine($"Setting Radio on {room}'s stereo");
        }

        public void SetVolume()
        {
            Console.WriteLine($"Setting Volume on {room}'s stereo");
        }
    }
}

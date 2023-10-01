namespace RemoteController.Models
{
    public class CeilingFan
    {
        public readonly RoomsEnum room;

        public CeilingFan(RoomsEnum room)
        {
            this.room = room;
        }

        public void TurnOnWithLowSpeed()
        {
            Console.WriteLine($"Turning on {room}'s ceiling fan with low speed");
        }

        public void TurnOnWithMediumSpeed()
        {
            Console.WriteLine($"Turning on {room}'s ceiling fan with medium speed");
        }

        public void TurnOnWithHighSpeed()
        {
            Console.WriteLine($"Turning on {room}'s ceiling fan with high speed");
        }

        public void TurnOff()
        {
            Console.WriteLine($"Turning off {room}'s ceiling fan");
        }
    }
}

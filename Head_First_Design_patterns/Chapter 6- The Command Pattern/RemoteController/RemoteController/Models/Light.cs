// See https://aka.ms/new-console-template for more information

namespace RemoteController.Models
{
    public class Light
    {
        public readonly RoomsEnum room;

        public Light(RoomsEnum room)
        {
            this.room = room;
        }

        public void TurnOn()
        {
            Console.WriteLine($"Turning On {room}'s light!");
        }

        public void TurnOff()
        {
            Console.WriteLine($"Turning Off {room}'s light!");
        }
    }
}
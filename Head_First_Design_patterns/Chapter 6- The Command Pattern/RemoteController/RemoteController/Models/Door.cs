namespace RemoteController.Models
{
    public class Door
    {
        public readonly RoomsEnum room;

        public Door(RoomsEnum room)
        {
            this.room = room;
        }

        public void Open()
        {
            Console.WriteLine($"Openning {room}'s door");
        }

        public void Close()
        {
            Console.WriteLine($"Closing {room}'s door");
        }
    }
}

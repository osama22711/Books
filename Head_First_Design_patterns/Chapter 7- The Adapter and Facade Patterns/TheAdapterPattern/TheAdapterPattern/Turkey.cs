using TheAdapterPattern.Interfaces;

namespace TheAdapterPattern
{
    public class Turkey : ITurkey
    {
        public void Fly()
        {
            Console.WriteLine("A Flying Turkey");
        }

        public void MakeSound()
        {
            Console.WriteLine("What does the Turkey sound like??? I don't know");
        }
    }
}

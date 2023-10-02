using TheAdapterPattern.Interfaces;

namespace TheAdapterPattern
{
    public class TurkeyDuckAdapter : IDuck
    {
        private readonly ITurkey turkey;

        public TurkeyDuckAdapter(ITurkey turkey)
        {
            this.turkey = turkey;
        }
        public void Fly()
        {
            this.turkey.Fly();
        }

        public void Quack()
        {
            this.turkey.MakeSound();
        }
    }
}

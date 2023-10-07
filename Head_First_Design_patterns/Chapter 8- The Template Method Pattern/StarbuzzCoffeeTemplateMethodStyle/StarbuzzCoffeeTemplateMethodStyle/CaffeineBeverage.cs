namespace StarbuzzCoffeeTemplateMethodStyle
{
    public abstract class CaffeineBeverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCoup();
            if (IsCondimentsDesired())
            {
                AddCondiments();
            }
        }

        public abstract void Brew();

        public abstract void AddCondiments();

        public virtual bool IsCondimentsDesired()
        {
            return true;
        }

        private void BoilWater()
        {
            Console.WriteLine("Boiling the water...");
        }

        private void PourInCoup()
        {
            Console.WriteLine("Pouring in the cup");
        }
    }
}

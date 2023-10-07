namespace StarbuzzCoffeeTemplateMethodStyle
{
    public class Coffee : CaffeineBeverage
    {
        public override void AddCondiments()
        {
            Console.WriteLine("Adding Cream");
        }

        public override void Brew()
        {
            Console.WriteLine("Adding Coffeee");
        }
    }
}

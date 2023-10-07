namespace StarbuzzCoffeeTemplateMethodStyle
{
    public class Tea : CaffeineBeverage
    {
        public override void AddCondiments()
        {
            Console.WriteLine("Adding Lemon..");
        }

        public override bool IsCondimentsDesired()
        {
            Console.WriteLine("I don't want anything, what do you mean with tea and lemon?!!");
            return false;
        }

        public override void Brew()
        {
            Console.WriteLine("Adding tea..");
        }
    }
}

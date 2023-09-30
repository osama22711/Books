namespace ThePizzaStore
{
    public abstract class Pizza
    {
        public string Name { get; set; }
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public readonly List<string> Toppings = new();

        public void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");
            Console.WriteLine($"Ttossing dough...");
            Console.WriteLine($"Adding Sauce");
            Console.WriteLine($"Adding Toppings");

            foreach (var topping in Toppings)
            {
                Console.WriteLine($"   {topping}");
            }
        }
        public void Bake()
        {
            Console.WriteLine($"Bake for 25 minutes at 350c");
        }
        public void Cut()
        {
            Console.WriteLine("Cutting the Pizza into diagonal slices");
        }
        public void Box()
        {
            Console.WriteLine("Place pizza in official PizzaStore box");
        }
    }
}
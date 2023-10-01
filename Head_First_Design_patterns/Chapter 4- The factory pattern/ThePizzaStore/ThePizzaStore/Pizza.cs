using ThePizzaStore.Ingredients;
using ThePizzaStore.Ingredients.Interfaces;

namespace ThePizzaStore
{
    public abstract class Pizza
    {
        public string Name { get; set; }
        public Dough Dough { get; set; }
        public Sauce Sauce { get; set; }
        public List<Veggies> Veggies { get; set; }
        public Cheese Cheese { get; set; }
        public Pepperoni Pepperoni { get; set; }
        public Clams Clams { get; set; }

        public abstract void Prepare();
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
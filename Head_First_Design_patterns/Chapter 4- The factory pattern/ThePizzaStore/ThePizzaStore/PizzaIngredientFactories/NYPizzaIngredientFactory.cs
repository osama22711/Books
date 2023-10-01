using ThePizzaStore.Ingredients;
using ThePizzaStore.Ingredients.Interfaces;

namespace ThePizzaStore.PizzaIngredientFactories
{
    public class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Cheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public Clams CreateClams()
        {
            return new FreshClams();
        }

        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Sauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public List<Veggies> CreateVeggies()
        {
            var veggies = new List<Veggies> { new Garlic(), new Onion(), new Mushroom(), new Redpepper() };
            return veggies;
        }
    }
}

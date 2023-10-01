using ThePizzaStore.Ingredients;
using ThePizzaStore.Ingredients.Interfaces;

namespace ThePizzaStore.PizzaIngredientFactories
{
    public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Cheese CreateCheese()
        {
            return new Mozzarella();
        }

        public Clams CreateClams()
        {
            return new FrozenClams();
        }

        public Dough CreateDough()
        {
            return new ThickCrustDough();
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Sauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public List<Veggies> CreateVeggies()
        {
            var veggies = new List<Veggies> { new BlackOlives(), new Spinach(), new EggPlant() };
            return veggies;
        }
    }
}

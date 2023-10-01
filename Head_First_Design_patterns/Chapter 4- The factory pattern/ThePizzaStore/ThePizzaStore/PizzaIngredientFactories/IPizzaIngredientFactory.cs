using ThePizzaStore.Ingredients;
using ThePizzaStore.Ingredients.Interfaces;

namespace ThePizzaStore.PizzaIngredientFactories
{
    public interface IPizzaIngredientFactory
    {
        public Dough CreateDough();
        public Sauce CreateSauce();
        public Cheese CreateCheese();
        public List<Veggies> CreateVeggies();
        public Pepperoni CreatePepperoni();
        public Clams CreateClams();
    }
}
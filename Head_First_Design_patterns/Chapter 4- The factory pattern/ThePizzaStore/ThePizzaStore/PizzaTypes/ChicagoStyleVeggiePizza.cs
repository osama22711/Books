using ThePizzaStore.PizzaIngredientFactories;

namespace ThePizzaStore.PizzaTypes
{
    public class ChicagoStyleVeggiePizza : Pizza
    {
        private readonly IPizzaIngredientFactory _pizzaIngredientFactory;

        public ChicagoStyleVeggiePizza(IPizzaIngredientFactory pizzaIngredientFactory)
        {
            _pizzaIngredientFactory = pizzaIngredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");
            Dough = _pizzaIngredientFactory.CreateDough();
            Sauce = _pizzaIngredientFactory.CreateSauce();
            Cheese = _pizzaIngredientFactory.CreateCheese();
        }
    }
}
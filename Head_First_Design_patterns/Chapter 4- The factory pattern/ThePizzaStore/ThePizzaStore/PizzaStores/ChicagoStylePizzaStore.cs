using ThePizzaStore.PizzaIngredientFactories;
using ThePizzaStore.PizzaTypes;

namespace ThePizzaStore.PizzaStores
{
    public class ChicagoStylePizzaStore : PizzaStore
    {
        private readonly string Verbiage = "{0} Chicago Style Pizza";
        public override Pizza? CreatePizza(PizzaEnum pizzaEnum)
        {
            var pizzaIngredientFactory = new ChicagoPizzaIngredientFactory();
            Pizza? pizza = null;
            string? name = null;

            switch (pizzaEnum)
            {
                case PizzaEnum.Cheese:
                    name = string.Format("Cheesy", Verbiage);
                    Console.WriteLine(name);
                    pizza = new ChicagoStyleCheesyPizza(pizzaIngredientFactory);
                    pizza.Name = name;
                    break;
                case PizzaEnum.Pepperoni:
                    name = string.Format("Pepporoni", Verbiage);
                    Console.WriteLine(name);
                    pizza = new ChicagoStylePepporoniPizza(pizzaIngredientFactory);
                    pizza.Name = name;
                    break;
                case PizzaEnum.Veggie:
                    name = string.Format("Veggie", Verbiage);
                    Console.WriteLine(name);
                    pizza = new ChicagoStyleVeggiePizza(pizzaIngredientFactory);
                    pizza.Name = name;
                    break;
                case PizzaEnum.Clam:
                    name = string.Format("Clam", Verbiage);
                    Console.WriteLine(name);
                    pizza = new ChicagoStyleClamPizza(pizzaIngredientFactory);
                    pizza.Name = name;
                    break;
            }

            return pizza;
        }
    }
}

using ThePizzaStore.PizzaIngredientFactories;
using ThePizzaStore.PizzaTypes;

namespace ThePizzaStore.PizzaStores
{
    public class NyStylePizzaStore : PizzaStore
    {
        private readonly string Verbiage = "{0} NewYork Style Pizza";
        public override Pizza? CreatePizza(PizzaEnum pizzaEnum)
        {
            var pizzaIngredientFactory = new NYPizzaIngredientFactory();
            Pizza? pizza = null;
            string? name = null;

            switch (pizzaEnum)
            {
                case PizzaEnum.Cheese:
                    name = string.Format(Verbiage, "Cheesy");
                    Console.WriteLine(name);
                    pizza = new NewYorkStyleCheesyPizza(pizzaIngredientFactory);
                    pizza.Name = name;
                    break;
                case PizzaEnum.Pepperoni:
                    name = string.Format(Verbiage, "Pepporoni");
                    Console.WriteLine(name);
                    pizza = new NewYorkStylePepporoniPizza(pizzaIngredientFactory);
                    pizza.Name = name;
                    break;
                case PizzaEnum.Veggie:
                    name = string.Format(Verbiage, "Veggie");
                    Console.WriteLine(name);
                    pizza = new NewYorkStyleVeggiePizza(pizzaIngredientFactory);
                    pizza.Name = name;
                    break;
                case PizzaEnum.Clam:
                    name = string.Format(Verbiage, "Clam");
                    Console.WriteLine(name);
                    pizza = new NewYorkStyleClamPizza(pizzaIngredientFactory);
                    pizza.Name = name;
                    break;
            }

            return pizza;
        }
    }
}

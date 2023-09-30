using ThePizzaStore.PizzaTypes;

namespace ThePizzaStore.PizzaStores
{
    public class NyStylePizzaStore : PizzaStore
    {
        private readonly string Verbiage = "{0} NewYork Style Pizza";
        public override Pizza? CreatePizza(PizzaEnum pizzaEnum)
        {
            Pizza? pizza = null;

            switch (pizzaEnum)
            {
                case PizzaEnum.Cheese:
                    Console.WriteLine(string.Format("Cheesy", Verbiage));
                    pizza = new NewYorkStyleCheesyPizza();
                    break;
                case PizzaEnum.Pepperoni:
                    Console.WriteLine(string.Format("Pepporoni", Verbiage));
                    pizza = new NewYorkStylePepporoniPizza();
                    break;
                case PizzaEnum.Veggie:
                    Console.WriteLine(string.Format("Veggie", Verbiage));
                    pizza = new NewYorkStyleVeggiePizza();
                    break;
                case PizzaEnum.Clam:
                    Console.WriteLine(string.Format("Clam", Verbiage));
                    pizza = new NewYorkStyleClamPizza();
                    break;
            }

            return pizza;
        }
    }
}

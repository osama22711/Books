using ThePizzaStore.PizzaTypes;

namespace ThePizzaStore.PizzaStores
{
    public class ChicagoStylePizzaStore : PizzaStore
    {
        private readonly string Verbiage = "{0} Chicago Style Pizza";
        public override Pizza? CreatePizza(PizzaEnum pizzaEnum)
        {
            Pizza? pizza = null;

            switch (pizzaEnum)
            {
                case PizzaEnum.Cheese:
                    Console.WriteLine(string.Format("Cheesy", Verbiage));
                    pizza = new ChicagoStyleCheesyPizza();
                    break;
                case PizzaEnum.Pepperoni:
                    Console.WriteLine(string.Format("Pepporoni", Verbiage));
                    pizza = new ChicagoStylePepporoniPizza();
                    break;
                case PizzaEnum.Veggie:
                    Console.WriteLine(string.Format("Veggie", Verbiage));
                    pizza = new ChicagoStyleVeggiePizza();
                    break;
                case PizzaEnum.Clam:
                    Console.WriteLine(string.Format("Clam", Verbiage));
                    pizza = new ChicagoStyleClamPizza();
                    break;
            }

            return pizza;
        }
    }
}

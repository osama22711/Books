namespace ThePizzaStore.PizzaStores
{
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(PizzaEnum pizzaEnum)
        {
            var pizza = CreatePizza(pizzaEnum);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        public abstract Pizza? CreatePizza(PizzaEnum pizzaEnum);
    }
}

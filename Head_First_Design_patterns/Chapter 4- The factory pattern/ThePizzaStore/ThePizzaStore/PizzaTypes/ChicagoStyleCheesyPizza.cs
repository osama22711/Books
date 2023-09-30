namespace ThePizzaStore.PizzaTypes
{
    public class ChicagoStyleCheesyPizza : Pizza
    {

        public ChicagoStyleCheesyPizza()
        {
            Name = "Chicago Style Sauce and Cheesy Pizza";
            Dough = "Thick Crust Dough";
            Sauce = "Marinara Sauce";

            Toppings.Add("Grated Reggiano Cheese");
        }
    }
}
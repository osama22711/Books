namespace ThePizzaStore.PizzaTypes
{
    public class ChicagoStylePepporoniPizza : Pizza
    {
        public ChicagoStylePepporoniPizza()
        {
            Name = "Chicago Style Sauce and Pepporoni Pizza";
            Dough = "Thick Crust Dough";
            Sauce = "Marinara Sauce";

            Toppings.Add("Grated Reggiano Cheese");
        }
    }
}
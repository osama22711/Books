namespace ThePizzaStore.PizzaTypes
{
    public class NewYorkStyleClamPizza : Pizza
    {
        public NewYorkStyleClamPizza()
        {
            Name = "NY Style Sauce and Clam Pizza";
            Dough = "Thing Crust Dough";
            Sauce = "Marinara Sauce";

            Toppings.Add("Grated Reggiano Cheese");
        }
    }
}
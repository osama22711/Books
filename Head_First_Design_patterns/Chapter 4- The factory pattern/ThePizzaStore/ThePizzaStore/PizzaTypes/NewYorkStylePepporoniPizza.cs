namespace ThePizzaStore.PizzaTypes
{
    public class NewYorkStylePepporoniPizza : Pizza
    {
        public NewYorkStylePepporoniPizza()
        {
            Name = "NY Style Sauce and Pepporoni Pizza";
            Dough = "Thing Crust Dough";
            Sauce = "Marinara Sauce";

            Toppings.Add("Grated Reggiano Cheese");
        }
    }
}
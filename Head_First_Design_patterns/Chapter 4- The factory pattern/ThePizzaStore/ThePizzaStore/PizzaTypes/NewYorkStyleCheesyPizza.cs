namespace ThePizzaStore.PizzaTypes
{
    public class NewYorkStyleCheesyPizza : Pizza
    {
        public NewYorkStyleCheesyPizza()
        {
            Name = "NY Style Sauce and Cheese Pizza";
            Dough = "Thing Crust Dough";
            Sauce = "Marinara Sauce";

            Toppings.Add("Grated Reggiano Cheese");
        }
    }
}
namespace ThePizzaStore.PizzaTypes
{
    public class NewYorkStyleVeggiePizza : Pizza
    {
        public NewYorkStyleVeggiePizza()
        {
            Name = "NY Style Sauce and Veggie Pizza";
            Dough = "Thing Crust Dough";
            Sauce = "Marinara Sauce";

            Toppings.Add("Grated Reggiano Cheese");
        }
    }
}
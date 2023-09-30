// See https://aka.ms/new-console-template for more information


using ThePizzaStore;
using ThePizzaStore.PizzaStores;

PizzaStore nyStore = new NyStylePizzaStore();
PizzaStore chicagoStore = new ChicagoStylePizzaStore();

Pizza pizza = nyStore.OrderPizza(PizzaEnum.Cheese);
Console.WriteLine($"Walid ordered a {pizza.Name} \n");

pizza = chicagoStore.OrderPizza(PizzaEnum.Pepperoni);
Console.WriteLine($"AboHasan ordered a {pizza.Name} \n");

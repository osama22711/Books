// See https://aka.ms/new-console-template for more information

using RestaurantWithDifferentMenus;
using RestaurantWithDifferentMenus.Menus;

var pancakeHouseMenu = new Menu("PANCAKE HOUSE MENU", "Breakfast");
var dinnerMenu = new Menu("DINER MENU", "Lunch");
var cafeMenu = new Menu("CAFE MENU", "Dinner");
var dessertMenu = new Menu("DESSERT MENU", "Dessert of course!");

var allMenus = new Menu("ALL MENUS", "All menus combined");

allMenus.Add(dinnerMenu);
allMenus.Add(cafeMenu);
allMenus.Add(pancakeHouseMenu);

dessertMenu.Add(new MenuItem("Mamoul",
                            "Date Mamoul",
                            true,
                            0.30));

cafeMenu.Add(new MenuItem("Mocha",
                            "Chocolate Milk",
                            true,
                            1.30));

pancakeHouseMenu.Add(new MenuItem("Keshk",
                            "Keshkeh Shamiyeh",
                            true,
                            2.50));

dinnerMenu.Add(new MenuItem("Pasta",
                            "Spaghetti with Marinara Sauce, and a slice of sourdough bread",
                            true,
                            3.89));
dinnerMenu.Add(dessertMenu);

var waitress = new Waitress(allMenus);

waitress.PrintMenu();
waitress.PrintVegetarianMenu();
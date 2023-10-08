using RestaurantWithDifferentMenus.Menus;

namespace RestaurantWithDifferentMenus
{
    public class Waitress
    {
        public MenuComponent AllMenus;

        public Waitress(MenuComponent allMenus)
        {
            AllMenus = allMenus;
        }

        public void PrintMenu()
        {
            AllMenus.Print();
        }

        public void PrintVegetarianMenu()
        {
            var iterator = AllMenus.CreateIterator();
            Console.WriteLine("-------------------");
            Console.WriteLine("Vegetarian Menu");
            Console.WriteLine("-------------------");
            while (iterator.MoveNext())
            {
                var menuComponent = (MenuComponent)iterator.Current;

                try
                {
                    if (menuComponent != null && menuComponent.IsVegetarian())
                    {
                        menuComponent.Print();
                    }
                }
                catch (Exception) { }
            }
        }
    }
}

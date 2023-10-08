using RestaurantWithDifferentMenus.Iterator;
using System.Collections;

namespace RestaurantWithDifferentMenus.Menus
{
    public class MenuItem : MenuComponent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Vegetarian { get; set; }
        public double Price { get; set; }

        public MenuItem(string name, string description, bool vegetarian, double price)
        {
            Name = name;
            Description = description;
            Vegetarian = vegetarian;
            Price = price;
        }

        public override string GetName()
        {
            return Name;
        }

        public override string GetDescription()
        {
            return Description;
        }

        public override double GetPrice()
        {
            return Price;
        }

        public override bool IsVegetarian()
        {
            return Vegetarian;
        }

        public override void Print()
        {
            Console.Write($"   {GetName()}");
            if (IsVegetarian())
            {
                Console.Write("(v)");
            }
            Console.WriteLine($",  {GetPrice()}");
            Console.WriteLine($"     --  {GetDescription()}");
        }

        public override void Add(MenuComponent menuComponent)
        {
            Console.WriteLine("");
        }

        public override void Remove(MenuComponent menuComponent)
        {
            Console.WriteLine("");
        }

        public override MenuComponent? GetChild(int i)
        {
            return null;
        }

        public override IEnumerator CreateIterator()
        {
            return new NullIterator();
        }
    }
}

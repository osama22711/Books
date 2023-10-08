using RestaurantWithDifferentMenus.Iterator;

namespace RestaurantWithDifferentMenus.Menus
{
    public class Menu : MenuComponent
    {
        IEnumerator<object> iterator = null;
        List<MenuComponent> menuComponents = new();
        private string name;
        private string description;

        public Menu(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public override void Add(MenuComponent menuComponent)
        {
            menuComponents.Add(menuComponent);
        }

        public override void Remove(MenuComponent menuComponent)
        {
            menuComponents.Remove(menuComponent);
        }

        public override MenuComponent GetChild(int i)
        {
            return menuComponents.ElementAt(i);
        }

        public override string GetName()
        {
            return name;
        }

        public override string GetDescription()
        {
            return description;
        }

        public override void Print()
        {
            Console.WriteLine(GetName() + ", " + GetDescription());
            Console.WriteLine("-----------------------------");

            var iterator = menuComponents.GetEnumerator();
            while (iterator.MoveNext())
            {
                var menuComponent = iterator.Current;
                menuComponent.Print();
            }
        }

        public override IEnumerator<object> CreateIterator()
        {
            if (iterator == null)
            {
                iterator = new CompositeIterator(menuComponents.GetEnumerator());
            }
            return iterator;
        }

        public override double GetPrice()
        {
            return 0;
        }

        public override bool IsVegetarian()
        {
            return false;
        }
    }
}

namespace RestaurantWithDifferentMenus.Menus
{
    public interface IMenuComponent
    {
        public void Add(MenuComponent menuComponent);
        public void Remove(MenuComponent menuComponent);
        public MenuComponent GetChild(int i);
        public string GetName();

        public string GetDescription();
        public double GetPrice();
        public bool IsVegetarian();
        public void Print();
    }
}

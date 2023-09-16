using ActionAdventureGame.WeaponBehavior;

namespace ActionAdventureGame.Client
{
    public class King : Character
    {
        public King(IWeaponBehavior weapon) : base(weapon)
        {
        }

        public override void Fight()
        {
            base.Fight();
            Console.WriteLine("King is fighting...");
        }
    }
}

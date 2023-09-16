using ActionAdventureGame.WeaponBehavior;

namespace ActionAdventureGame.Client
{
    public class Troll : Character
    {
        public Troll(IWeaponBehavior weapon) : base(weapon)
        {
        }

        public override void Fight()
        {
            base.Fight();
            Console.WriteLine("Troll is fighting...");
        }
    }
}

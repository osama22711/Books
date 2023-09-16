using ActionAdventureGame.WeaponBehavior;

namespace ActionAdventureGame.Client
{
    public class Knight : Character
    {
        public Knight(IWeaponBehavior weapon) : base(weapon)
        {
        }

        public override void Fight()
        {
            base.Fight();
            Console.WriteLine("Knight is fighting...");
        }
    }
}

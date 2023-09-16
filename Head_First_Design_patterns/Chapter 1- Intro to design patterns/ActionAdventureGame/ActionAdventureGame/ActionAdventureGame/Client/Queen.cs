using ActionAdventureGame.WeaponBehavior;

namespace ActionAdventureGame.Client
{
    public class Queen : Character
    {
        public Queen(IWeaponBehavior weapon) : base(weapon)
        {
        }

        public override void Fight()
        {
            base.Fight();
            Console.WriteLine("Queen is fighting...");
        }
    }
}

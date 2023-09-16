using ActionAdventureGame.WeaponBehavior;

namespace ActionAdventureGame.Client
{
    public class Character
    {
        public IWeaponBehavior weapon;

        public Character(IWeaponBehavior weapon)
        {
            this.weapon = weapon;
        }

        public virtual void Fight()
        {
            weapon.UseWeapon();
        }

        public void SetWeapon(IWeaponBehavior newWeapon)
        {
            this.weapon = newWeapon;
        }
    }
}

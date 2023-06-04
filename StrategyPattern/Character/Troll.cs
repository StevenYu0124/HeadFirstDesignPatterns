public class Troll : ICharacter
{
    public IWeaponBehavior? WeaponBehavior { get; set; }

    public void Fight()
    {
        if (WeaponBehavior == null) return;
        WeaponBehavior.UseWeapon();
    }
}
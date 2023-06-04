public interface ICharacter
{
    public IWeaponBehavior? WeaponBehavior { get; set; }
    public void Fight();
}
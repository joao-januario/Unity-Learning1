using Static.Enums;

namespace Interfaces.Scriptables
{
public interface IWeaponType
{
    WeaponName GetName();
    float GetDamage();
    float GetFireRate();

}
}
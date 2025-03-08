using Static.Enums;

namespace Interfaces.Scriptables
{
public interface IGunType : IWeaponType
{
    GunFireType FireType();
}
}
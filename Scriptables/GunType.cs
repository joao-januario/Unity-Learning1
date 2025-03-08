using Interfaces.Scriptables;
using Static.Enums;
using UnityEngine;

namespace Scriptables
{
[CreateAssetMenu(fileName = "GunType", menuName = "ScriptableObjects/GunType")]
public class GunType : ScriptableObject,IGunType
{
    [SerializeField] private WeaponName weaponName;
    [SerializeField] private int baseDamage;
    [SerializeField] private float baseFireRate;
    [SerializeField] private GunFireType gunFireType;

    public WeaponName GetName() => weaponName;

    public float GetDamage() => baseDamage;
    
    public float GetFireRate() => baseFireRate;

    public GunFireType FireType() => gunFireType;

    public override string ToString() => $"GunType: {weaponName}, Damage: {baseDamage}, FireRate: {baseFireRate}, FireType: {gunFireType}";
}
}

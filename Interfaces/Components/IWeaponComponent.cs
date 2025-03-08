using Interfaces.Scriptables;
using Static.Enums;
using UnityEngine;

namespace Interfaces.Components
{
public interface IWeaponComponent
{
    /**
    * Best attempt at immutability since
    * Unity does not support parameters on Awake()
    */
    IWeaponComponent Init(IGunType gunType, Transform playerTransform);
    void Attack();

    WeaponName GetName();
}
}
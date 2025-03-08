using System.Collections.Generic;
using Components.Weapon;
using Interfaces.Components;
using Scriptables;
using Static.Enums;
using UnityEngine;
using UnityEngine.InputSystem;
using static Static.Enums.WeaponName;
using static Static.StaticStrings;

namespace Components.Player
{
public class PlayerComponent : MonoBehaviour
{
    
    private Dictionary<WeaponName,IWeaponComponent> availableWeapons;
    private InputAction fireAction;
    private IWeaponComponent activeWeapon;
    
    private void OnEnable()
    {
        availableWeapons = new Dictionary<WeaponName, IWeaponComponent>();
        foreach (var gunType in Resources.LoadAll<GunType>(GUN_PATH))
        {
            availableWeapons.Add(gunType.GetName(),gameObject.AddComponent<GunComponent>().Init(gunType,GetComponent<Transform>()));
        }
        activeWeapon = availableWeapons[Pistol];
        var inputActions = GetComponent<PlayerInput>().actions;
        inputActions.Enable();
        inputActions[SWITCH_TO_PISTOL].performed += _ => SwitchToPistol();
        inputActions[SWITCH_TO_RIFLE].performed += _ => SwitchToRifle();
        inputActions[CHECK_CURRENT].performed += _ => LogCurrentWeapon();
        fireAction = GetComponent<PlayerInput>().actions[INTERACT];
        
    }
    
    private void SwitchToPistol()
    {
        if (activeWeapon.GetName() == Pistol) return;
        activeWeapon = availableWeapons[Pistol];
        Debug.Log("Switched to Pistol");

    }

    private void SwitchToRifle()
    {
        if (activeWeapon.GetName() == Rifle) return;
        activeWeapon = availableWeapons[Rifle];
        Debug.Log("Switched to Rifle");
    }

    private void LogCurrentWeapon()
    {
        Debug.Log($"Current Weapon: {activeWeapon}");
    }

    private void FixedUpdate()
    {
        if (fireAction.IsPressed())
        {
            activeWeapon.Attack();
        }
    }
    
}
}


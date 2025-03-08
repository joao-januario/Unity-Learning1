using Interfaces.Components;
using Interfaces.Scriptables;
using Static.Enums;
using UnityEngine;
using static Static.StaticStrings;

namespace Components.Weapon
{
public class GunComponent : MonoBehaviour,IWeaponComponent
{
    private IGunType gunType;
    //Gun has no transform in this project
    private Transform playerTransform;
    private float timeSinceLastShot;
    private GameObject bulletPrefab;

    public IWeaponComponent Init(IGunType gunType, Transform playerTransform)
    {
        this.gunType = gunType;
        timeSinceLastShot = -999f;
        this.playerTransform = playerTransform;
        bulletPrefab = Resources.Load<GameObject>(BULLET_PATH);
        return this;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void Attack()
    {
        if (!(Time.time > timeSinceLastShot + 1f / gunType.GetFireRate())) return;
        
        timeSinceLastShot = Time.time;
        var bullet = Instantiate(bulletPrefab, playerTransform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
        bullet.GetComponent<BulletComponent>().SetDamage(gunType.GetDamage());
    }

    public WeaponName GetName()
    {
        return gunType.GetName();
    }
}
}
using Static;
using UnityEngine;

namespace Components.Weapon
{
public class BulletComponent : MonoBehaviour
{
    private Rigidbody2D rigidB;
    [SerializeField] private float bulletVelocity = 1f;
    private float damage;
    
    private void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        rigidB.linearVelocity = new Vector2(bulletVelocity, 0);
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EventManager.TriggerDamageDealt(other.gameObject,damage);
        Destroy(gameObject);
    }
}
}
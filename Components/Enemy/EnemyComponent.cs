using Scriptables;
using Static;
using UnityEngine;

namespace Components.Enemy
{
public class EnemyComponent : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    private HealthComponent healthComponent;

    private void Awake()
    {
        healthComponent = new HealthComponent(enemyType.GetBaseHealth());
    }

    private void OnEnable()
    {
        EventManager.RegisterOnDamageDealt(gameObject,HandleDamageDealt);
    }

    private void OnDisable()
    {
        EventManager.UnregisterOnDamageDealt(gameObject);
    }

    private void HandleDamageDealt(float damage)
    {
        healthComponent.HandleDamage(damage);
        if (!healthComponent.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
}
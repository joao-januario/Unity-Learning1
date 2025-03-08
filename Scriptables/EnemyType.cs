using UnityEngine;

namespace Scriptables
{
[CreateAssetMenu(fileName = "EnemyType", menuName = "ScriptableObjects/EnemyType")]
public class EnemyType : ScriptableObject
{
    [SerializeField] private float baseHealth;

    public float GetBaseHealth()
    {
        return baseHealth;
    }
}
}
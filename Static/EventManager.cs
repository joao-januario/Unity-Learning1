using System;
using System.Collections.Generic;
using UnityEngine;

namespace Static
{
public static class EventManager
{
    public static Dictionary<GameObject, Action<float>> OnDamageDealt = new();

    public static void RegisterOnDamageDealt(GameObject gameObject, Action<float> action)
    {
        OnDamageDealt.Add(gameObject,action);
    }

    public static void UnregisterOnDamageDealt(GameObject gameObject)
    {
        OnDamageDealt.Remove(gameObject);
    }
    public static void TriggerDamageDealt(GameObject gameObject, float damage)
    {
        if (OnDamageDealt.ContainsKey(gameObject))
        {
            OnDamageDealt[gameObject]?.Invoke(damage);
        }
    }
}
}
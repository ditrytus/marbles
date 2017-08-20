using UnityEngine;
using System.Linq;

public static class EnabilityGameObjectExtensions
{
    public static void Enable(this GameObject gameObject)
    {
        gameObject.SetEnable(true);
    }

    public static void Disable(this GameObject gameObject)
    {
        gameObject.SetEnable(false);
    }

    private static void SetEnable(this GameObject gameObject, bool enableValue)
    {
        gameObject.SetActive(enableValue);
        var behaviors = gameObject.GetComponents<MonoBehaviour>();
        behaviors.ToList().ForEach(b => b.enabled = enableValue);
    }
}
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

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

    public static void EnableAll(this IEnumerable<GameObject> gameObjects)
    {
        gameObjects.SetEnableForAll(true);
    }

    public static void DisableAll(this IEnumerable<GameObject> gameObjects)
    {
        gameObjects.SetEnableForAll(false);
    }

    private static void SetEnableForAll(this IEnumerable<GameObject> gameObjects, bool enableValue)
    {
        foreach(var obj in gameObjects)
		{
			obj.SetEnable(enableValue);
		}
    }

    private static void SetEnable(this GameObject gameObject, bool enableValue)
    {
        gameObject.SetActive(enableValue);
        var behaviors = gameObject.GetComponents<MonoBehaviour>();
        behaviors.ToList().ForEach(b => b.enabled = enableValue);
    }
}
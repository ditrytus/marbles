using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Disabler : IDisposable
{
	private GameObject[] objectsToReactivate;

    public Disabler(IEnumerable<GameObject> gameObjects)
    {
		objectsToReactivate = gameObjects.Where(go => go.activeSelf).ToArray();
		gameObjects.DisableAll();
    }

    public void Dispose()
    {
        objectsToReactivate.EnableAll();
    }
}

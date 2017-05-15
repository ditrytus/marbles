using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnAtWithTimeout : MonoBehaviour
{
    public GameObject prefab;

	public Transform parent;

	public Transform spawnPoint;

	public float timeout = 0.0f;

    public void Spawn()
    {
        var created = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, parent);
        if (timeout > 0.0f)
        {
            Destroy(created, timeout);
        }
    }    
}
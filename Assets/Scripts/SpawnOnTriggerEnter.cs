using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnTriggerEnter : MonoBehaviour {

	public GameObject prefab;

	public Transform parent;

	public Transform spawnPoint;

	public float timeout = 0.0f;

	void OnTriggerEnter()
	{
		var created = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, parent);
		if (timeout > 0.0f)
		{
			Destroy(created, timeout);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnOnIntervalMaxCountTo : MonoBehaviour {

	public SpawnOnInterval spawnOnInterval;

	public int newCountValue = 0;

	public void SetNewCount()
	{
		spawnOnInterval.count = newCountValue;
	}
}

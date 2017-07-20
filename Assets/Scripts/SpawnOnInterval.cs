using UnityEngine;
using UniRx;
using System;

public class SpawnOnInterval : MonoBehaviour {
	public float interval;

	public int maxCount = -1;

	public GameObject prefab;

	public GameObject spawnPoint;

	public GameObject parent;

	public IObservable<Unit> SpawningFinished
	{
		get
		{
			return spawningFinished;
		}
	}

	private Subject<Unit> spawningFinished = new Subject<Unit>();

	private float startTime;

	private int count = 0;

	void Start ()
	{
		startTime = PausableTime.Instance.Time;
	}

	void Update()
	{
		if (PausableTime.Instance.IsPaused)
		{
			return;
		}

		if (count >= maxCount)
		{
			return;
		}

		var deltaTime = PausableTime.Instance.Time - startTime;
		if (deltaTime >= interval)
		{
			var obj = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation, parent.transform);
			obj.layer = this.gameObject.layer;

			startTime = PausableTime.Instance.Time;
			count++;

			if (count >= maxCount)
			{
				spawningFinished.OnNext(Unit.Default);				
			}
		}
	}
}

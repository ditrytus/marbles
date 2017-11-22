using UnityEngine;
using UniRx;
using System;

public class SpawnOnInterval : MonoBehaviour, IDelayedInterval {
	public float interval;

	public float delay;

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

    float IDelayedInterval.Interval
    {
        get
        {
            return interval;
        }
    }

    float IDelayedInterval.Delay
	{ 
		get
		{
			return delay;
		}
		set
		{
			delay = value;
		}
	}

    int IDelayedInterval.MaxCount
    {
        get
        {
            return maxCount;
        }
    }

    private Subject<Unit> spawningFinished = new Subject<Unit>();

	private float startTime;

	public int count = 0;

	void Start ()
	{
		startTime = PausableTime.Instance.Time + delay;
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

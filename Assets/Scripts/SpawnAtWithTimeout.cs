using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public abstract class SpawnAtWithTimeout : RxBehaviour
{
    public GameObject prefab;

	public Transform parent;

	public Transform spawnPoint;

	public float timeout = 0.0f;

    public void Spawn()
    {
        var createdObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, parent);
        if (timeout > 0.0f)
        {
            var sub = new[] { createdObject }
                .ToObservable()
                .Delay(TimeSpan.FromSeconds(timeout / PausableTime.Instance.TimeScale), new PausableMainThreadScheduler())
                .Subscribe(obj => 
                {
                    Destroy(obj);
                });
            AddSubscriptions(sub);
        }
    }
}
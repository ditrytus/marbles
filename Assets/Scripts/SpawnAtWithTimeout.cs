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

    //private GameObject createdObject;

    public void Spawn()
    {
        var createdObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, parent);
        if (timeout > 0.0f)
        {
            var sub = new[] { createdObject }
                .ToObservable()
                .Delay(TimeSpan.FromSeconds(timeout), new PausableMainThreadScheduler())
                .Subscribe(obj => 
                {
                    Destroy(obj);
                });
            // var sub = Observable
            //     .Timer(TimeSpan.FromSeconds(timeout), new PausableMainThreadScheduler())
            //     .Subscribe(_ => 
            //     {
            //         Destroy(createdObject);
            //     });
            AddSubscriptions(sub);
        }
    }
}
using UnityEngine;
using UniRx;
using System;

public class SpawnOnInterval : RxBehaviour {
	public float interval;

	public GameObject prefab;

	public Transform spawnPoint;

	void Start () {
		var sub1 =Observable.Interval(TimeSpan.FromSeconds(interval))
			.Subscribe(_ => {
				Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
			});
		AddSubscriptions(sub1);
	}
}

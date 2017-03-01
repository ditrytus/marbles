using UnityEngine;
using UniRx;
using System;

public class SpawnOnInterval : RxBehaviour {
	public float interval;

	public int maxCount = -1;

	public GameObject prefab;

	public GameObject spawnPoint;

	void Start () {
		var intervalObservable = Observable.Interval(TimeSpan.FromSeconds(interval));
		intervalObservable = maxCount < 0 ? intervalObservable : intervalObservable.Take(maxCount);
		var sub1 = intervalObservable
			.Subscribe(_ => {
				var obj = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
				obj.layer = this.gameObject.layer;
			});
		AddSubscriptions(sub1);
	}
}

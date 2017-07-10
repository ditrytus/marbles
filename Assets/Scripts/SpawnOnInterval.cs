using UnityEngine;
using UniRx;
using System;

public class SpawnOnInterval : RxBehaviour {
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

	void Start () {
		var intervalObservable = Observable.Interval(TimeSpan.FromSeconds(interval));
		intervalObservable = maxCount < 0 ? intervalObservable : intervalObservable.Take(maxCount);
		var sub1 = intervalObservable
			.Subscribe(
				_ => {
					var obj = Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation, parent.transform);
					obj.layer = this.gameObject.layer;
				},
				() => {
					spawningFinished.OnNext(Unit.Default);
				}
			);
		AddSubscriptions(sub1);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class DestroyOnWrongColor : RxBehaviour {

	public int delay;

	public FloatRange radiusRange;

	public float wiggleTime;

	public GameObject particlePrefab;

	private bool isDestroying = false;

	private float startTime;

	private RandomizePosition randomizePosition;

	public void MarbleColorIsWrong()
	{
		if (isDestroying)
		{
			return;
		}
		isDestroying = true;

		var sub1 = Observable.Timer(TimeSpan.FromSeconds(delay))
			.Subscribe(_ => {
				GetComponent<Rigidbody>().isKinematic = true;
				GetComponents<Collider>().ToList().ForEach(c => c.isTrigger = true);
				
				startTime = Time.time;

				randomizePosition = gameObject.AddComponent<RandomizePosition>();
				randomizePosition.radius = 0.0f;

				var sub2 = Observable.EveryUpdate()
					.Subscribe(__ => {
						randomizePosition.radius = Mathf.Lerp(
							radiusRange.min,
							radiusRange.max,
							(Time.time - startTime) / wiggleTime);
					});

				Observable.Timer(TimeSpan.FromSeconds(wiggleTime))
					.Subscribe(__ => {
						var explosion = Instantiate(particlePrefab, transform.position, transform.rotation);
						explosion.SendMessage(MarbleColorController.SetMarbleColorMessage, gameObject.GetComponent<MarbleColorController>().color);
						Destroy(gameObject);
					});

				AddSubscriptions(sub2);
			});

		AddSubscriptions(sub1);
	}
}

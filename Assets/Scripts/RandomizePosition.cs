using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class RandomizePosition : RxBehaviour {

	public AxesFilter randomize = AxesFilter.All;

	public float radius = 1.0f;

	private Vector3 originalPosition;

	void Start () {
		originalPosition = transform.position;
		
		var sub1 = Observable.EveryUpdate()
			.Subscribe(_ => {
				var point = Random.insideUnitSphere * radius;

				transform.position = new Vector3(
					randomize.x ? originalPosition.x + point.x : transform.position.x,
					randomize.y ? originalPosition.y + point.y : transform.position.y,
					randomize.z ? originalPosition.z + point.z : transform.position.z);
			});

		AddSubscriptions(sub1);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}

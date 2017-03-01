using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class RandomizePosition : RxBehaviour {

	public bool randomizeX = true;

	public bool randomizeY = true;

	public bool randomizeZ = true;

	public float radius = 1.0f;

	private Vector3 originalPosition;

	void Start () {
		originalPosition = transform.position;
		
		var sub1 = Observable.EveryUpdate()
			.Subscribe(_ => {
				var point = Random.insideUnitSphere * radius;

				transform.position = new Vector3(
					randomizeX ? originalPosition.x + point.x : transform.position.x,
					randomizeY ? originalPosition.y + point.y : transform.position.y,
					randomizeZ ? originalPosition.z + point.z : transform.position.z);
			});

		AddSubscriptions(sub1);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class RandomizePosition : MonoBehaviour {

	public AxesFilter randomize = AxesFilter.All;

	public float radius;

	private Vector3 originalPosition;

	void Start () {
		originalPosition = transform.position;
	}

	void Update()
	{
		var point = Random.insideUnitSphere * radius;

		transform.position = originalPosition + point.Filter(randomize);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}

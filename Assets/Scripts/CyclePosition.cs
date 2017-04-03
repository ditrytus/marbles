using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclePosition : MonoBehaviour {

	public Vector3 direction;

	public float initialShift;

	private Vector3 initialPosition;

	public float speed;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// var normalizedPosition = new Vector3(
		// 	Mathf.Sin(initialPosition.x + Time.time * speed.x),
		// 	Mathf.Sin(initialPosition.y + Time.time * speed.y),
		// 	Mathf.Sin(initialPosition.z + Time.time * speed.z));

		transform.position = initialPosition + direction * Mathf.Sin((initialShift / speed + Time.time) * speed * 2 * Mathf.PI);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclePosition : MonoBehaviour
{
	public Vector3 direction;

	public float initialShift;

	private Vector3 initialPosition;

	public float speed;

    void Start ()
	{
		initialPosition = transform.position;
	}
	
	void Update ()
	{
		if (PausableTime.Instance.IsPaused)
		{
			return;
		}

		transform.position = initialPosition + direction * Mathf.Sin((initialShift / speed + PausableTime.Instance.Time) * speed * 2 * Mathf.PI);
	}
}

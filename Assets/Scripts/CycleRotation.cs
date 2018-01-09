using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleRotation : MonoBehaviour
{
	public Vector3 angles;

	public float initialShift;

	private Vector3 initialAngles;

	public float speed;

	public float cycleInterval;

    void Start ()
	{
		initialAngles = transform.rotation.eulerAngles;
	}
	
	void Update ()
	{
		if (PausableTime.Instance.IsPaused)
		{
			return;
		}

		transform.rotation = Quaternion.Euler(initialAngles + angles * (Mathf.Sin((initialShift / speed + PausableTime.Instance.Time) * speed * 2 * Mathf.PI) + 1.0f)/2.0f);
	}
}

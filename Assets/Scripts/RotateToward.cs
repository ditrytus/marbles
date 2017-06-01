using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToward : MonoBehaviour
{

	public Transform destination;

	public float duration;

	public Vector3 direction = Vector3.forward;

	private Quaternion startRotation;

	private Vector3 startDirection;

	private Vector3 prevDestDir;

	private bool isRotating = false;

	private float startTime;

	// Use this for initialization
	void Start ()
	{
		prevDestDir = destination.TransformDirection(direction);
	}
	
	// Update is called once per frame
	void Update ()
	{
        Vector3 destDir = destination.TransformDirection(direction);
		if (!isRotating && destDir != prevDestDir)
		{
			isRotating = true;
			prevDestDir = destDir;
			startTime = Time.time;
			startRotation = transform.rotation;
			startDirection = transform.TransformDirection(direction);
		}
		if (isRotating)
		{
			var t = (Time.time - startTime) / duration;
			if (t < 1.0)
			{
				transform.rotation = startRotation * Quaternion.Lerp(
					Quaternion.identity,
					Quaternion.FromToRotation(startDirection, destDir),
					Mathf.SmoothStep(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, t)));
			}
			else
			{
				isRotating = false;
			}
		}
	}
}

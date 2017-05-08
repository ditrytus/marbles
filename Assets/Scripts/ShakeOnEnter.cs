using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnEnter : MonoBehaviour
{
	public float shakeTime;

	public float angleDeviation;

	public float shakeFactor = 1.0f;

	public GameObject shakedObject;

	private bool isShaking;
	
	private float startTime;

	private float initialAngle;

	// Update is called once per frame
	void Update ()
	{
		if (isShaking)
		{
			var deltaTime = Time.time - startTime;
			if (deltaTime >= shakeTime)
            {
                SetRotation(initialAngle);
				isShaking = false;
            }
            else
			{
				var t = (deltaTime / shakeTime);
                SetRotation(Mathf.Cos(t * shakeFactor) * Mathf.Lerp(angleDeviation, 0.0f, t) + initialAngle);
			}
		}
	}

    private void SetRotation(float newAngle)
    {
        shakedObject.transform.localEulerAngles = new Vector3(
			shakedObject.transform.localEulerAngles.x,
			shakedObject.transform.localEulerAngles.y,
			newAngle
		);
    }

    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag(Tags.Marble))
		{
			startTime = Time.time;
			initialAngle = shakedObject.transform.localRotation.z;
			isShaking = true;
		}
    }
}

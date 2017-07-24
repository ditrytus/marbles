using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	public Vector3 degreesPerSecond;
	
	public bool reversePause = false;

	void Update ()
	{
		if (reversePause ^ PausableTime.Instance.IsPaused)
		{
			return;
		}

		transform.Rotate(degreesPerSecond * Time.deltaTime);	
	}
}

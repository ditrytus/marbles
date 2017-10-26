using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeProvider : MonoBehaviour
{
	public float timeSinceLevelLoad;

	public float framerate;

	void Update ()
	{
		timeSinceLevelLoad = Time.timeSinceLevelLoad;
		framerate = 1.0f / Time.deltaTime;
	}
}

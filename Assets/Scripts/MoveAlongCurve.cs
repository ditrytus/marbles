using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongCurve : MonoBehaviour {

	private Curve curve;

	private float duration;

	private float startTime;

	// Use this for initialization
	void Start () {
		curve = GetComponentInParent<Curve>();
        duration = GetComponentInParent<SwitchTriggerBase>().delay;
		startTime = Time.time;	
	}
	
	// Update is called once per frame
	void Update ()
	{
		var currentTime = Time.time - startTime;
        var currentDistance = Mathf.Lerp(0.0f, curve.length, currentTime / duration);

		var distanceSoFar = 0.0f;
		for (int i=0; i<curve.positions.Length-1; i++)
		{
			var segmentDistance = Vector3.Distance(curve.positions[i], curve.positions[i+1]);
			if (distanceSoFar <= currentDistance && currentDistance < (distanceSoFar + segmentDistance))
			{
                transform.position = Vector3.Lerp(
                    curve.positions[i],
                    curve.positions[i + 1],
                    (currentDistance - distanceSoFar) / segmentDistance);
				break;
			}
			distanceSoFar += segmentDistance;
		}
	}
}

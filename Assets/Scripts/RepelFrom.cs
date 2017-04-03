using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelFrom : MonoBehaviour {

	public Transform repellent;

	public float threshold;
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(repellent.position, transform.position) < threshold)
		{
			transform.Translate(Vector3.back * threshold, Space.Self);
		}
	}
}

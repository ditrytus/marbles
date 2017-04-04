using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionToMiddleOfCamera : MonoBehaviour {

	public Camera cam;

	public Transform farObject;
	
	// Update is called once per frame
	void Update () {
		transform.position = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cam.WorldToViewportPoint(farObject.position).z));
	}
}

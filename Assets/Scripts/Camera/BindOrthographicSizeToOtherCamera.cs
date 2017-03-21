using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindOrthographicSizeToOtherCamera : MonoBehaviour {

	public Camera otherCamera;
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Camera>().orthographicSize = otherCamera.orthographicSize;
	}
}

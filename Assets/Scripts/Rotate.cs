using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public Vector3 degreesPerSecond;
	
	void Update ()
	{
		transform.Rotate(degreesPerSecond * Time.deltaTime);	
	}
}

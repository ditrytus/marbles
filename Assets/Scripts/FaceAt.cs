using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAt : MonoBehaviour {

	public Transform observedObject;

	void Update()
	{
		this.transform.LookAt(observedObject);
		this.transform.forward = -this.transform.forward;
	}
}

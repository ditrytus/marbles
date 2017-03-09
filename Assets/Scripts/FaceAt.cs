using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAt : MonoBehaviour {

	public GameObject observedObject;

	public AxesFilter filter = AxesFilter.All;

	void Update()
	{
		this.transform.rotation = Quaternion.LookRotation(observedObject.transform.position.Filter(filter));
		this.transform.forward = -this.transform.forward;
	}
}

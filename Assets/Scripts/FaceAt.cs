using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FaceAt : MonoBehaviour {

	public GameObject observedObject;

	public string observedObjectTag;

	public AxesFilter filter = AxesFilter.All;

	void Start()
	{
		if (observedObject == null && !string.IsNullOrEmpty(observedObjectTag))
		{
			observedObject = GameObject.FindGameObjectWithTag(observedObjectTag);
		}
	}

	void Update()
	{
		this.transform.rotation = Quaternion.LookRotation(observedObject.transform.position.Filter(filter));
		this.transform.forward = -this.transform.forward;
	}
}

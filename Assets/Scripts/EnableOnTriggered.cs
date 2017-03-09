using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnTriggered : MonoBehaviour {

	public GameObject objectToDisable;

	public string filterTag;
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag(filterTag))
		{
			objectToDisable.Disable();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag(filterTag))
		{
			objectToDisable.Enable();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftToLayerOnTriggerEnter : MonoBehaviour {

	public string filterTag = "Marble";

	public LayerMask onEnterLayer;
	public LayerMask onExitLayer;

	void OnTriggerEnter(Collider other)
	{
		SetLayerForFilter(other.gameObject, onEnterLayer.value);
	}

	void OnTriggerExit(Collider other)
	{
		SetLayerForFilter(other.gameObject, onExitLayer.value);
	}

	void SetLayerForFilter(GameObject gObject, int layer)
	{
		if (gObject.CompareTag(filterTag))
		{
			gObject.layer = layer;
		}
	}
}

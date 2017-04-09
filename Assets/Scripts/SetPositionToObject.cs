using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class SetPositionToObject : MonoBehaviour {

	public Transform otherObject;
	
	void Update ()
	{
		if (otherObject != null)
		{
			transform.position = otherObject.position;
		}
	}
}

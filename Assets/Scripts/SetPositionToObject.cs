using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
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

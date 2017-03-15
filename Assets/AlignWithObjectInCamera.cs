using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class AlignWithObjectInCamera : MonoBehaviour {

	public Transform target;

	public Camera viewCamera;

	public Vector2 offset;

	void Start ()
    {
        Align();
    }

    private void Align()
    {
        if (viewCamera == null)
        {
            throw new InvalidOperationException("View camera is not set!");
        }
        var targetCameraPos = viewCamera.WorldToScreenPoint(target.position);
        var trans = GetComponent<RectTransform>();
        if (trans == null)
        {
            throw new InvalidOperationException("There is no RectTransform attached!");
        }
        trans.anchoredPosition = (Vector2)targetCameraPos + offset;
    }

    void Update ()
	{
		Align();
	}
}

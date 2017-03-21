using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ZoomWithPinch : ZoomBase {
	
	private int touch1Id;

	private int touch2Id;

	private bool isZooming = false;

	void Update ()
	{
		if (!isZooming && Input.touchCount == 2 && Input.touches.Any(t => t.phase == TouchPhase.Began))
		{
			touch1Id = Input.touches[0].fingerId;
			touch2Id = Input.touches[1].fingerId;
			isZooming = true;
			Debug.Log("Zoom started.");
		}

		if (isZooming && Input.touchCount < 2)
		{
			isZooming = false;
			Debug.Log("Zoom ended.");
		}

		if (isZooming)
		{
			var touch1 = Input.GetTouch(touch1Id);
			var touch2 = Input.GetTouch(touch2Id);

			var oldPos1 = touch1.position - touch1.deltaPosition;
			var oldPos2 = touch2.position - touch2.deltaPosition;

			var oldDistance = Vector2.Distance(oldPos1, oldPos2);
			var newDistance = Vector2.Distance(touch1.position, touch2.position);

			var oldMiddle = (oldPos1 + oldPos2) / 2.0f;
			var newMiddle = (touch1.position + touch2.position) / 2.0f;

			var zoomDelta = newDistance - oldDistance;
			if (zoomDelta != 0)
			{
				ZoomCameraInCenter(oldDistance - newDistance, newMiddle);
			}
		}
	}
}

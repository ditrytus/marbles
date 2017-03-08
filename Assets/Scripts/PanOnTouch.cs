using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class PanOnTouch : RxBehaviour {

	public Camera cam;

	private Vector3 velocity;

	public AxesFilter constraint = AxesFilter.All;

	public float glide;

	private bool isGliding = false;

	private float glidedTime = 0;

	void Update()
	{
		if (Input.touchCount > 0)
		{
			isGliding = false;
		}

		if (Input.touchCount == 1)
		{
			var touch = Input.touches.First();
			if (touch.phase == TouchPhase.Moved)
			{
				var d = (Vector3)(touch.deltaPosition) * cam.orthographicSize / cam.pixelHeight * 2f;

				var c = d / Mathf.Sin(0.5f * Mathf.PI - Mathf.Deg2Rad * Vector3.Angle(cam.transform.up, Vector3.up));

				velocity = new Vector3(
					constraint.x ? 0.0f : d.x,
					constraint.y ? 0.0f : d.y,
					constraint.z ? 0.0f : d.z);
				
				cam.transform.position -= velocity;
			}
			else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
			{
				isGliding = true;
				glidedTime = 0;
			}
		}
		
		if (isGliding)
		{
			glidedTime += Time.deltaTime;

			cam.transform.position -= Vector3.Lerp(velocity, Vector3.zero, glidedTime / glide);

			if (glidedTime > glide)
			{
				isGliding = false;
			}
		}
	}
}

using UnityEngine;
using System;
using System.Linq;

public class PanOnTouch : MonoBehaviour {

	public Camera cam;

	private Vector3 velocity;

	public AxesFilter constraint = AxesFilter.All;

	public float glide;

	private bool isGliding = false;

	private float glidedTime = 0;

	public int mousePanButton = 0;

	private Vector3? previousMousePosition = new Vector3();

	void Update()
    {
		if (Input.touchSupported)
        {
            PanWithTouch();
        }
        else
        {
            PanWithMouse();
        }
    }

    private void PanWithMouse()
    {
        if (Input.GetMouseButton(mousePanButton))
        {
            if (Input.GetMouseButtonDown(mousePanButton))
            {
                EndGlide();
            }

			if (previousMousePosition.HasValue)
			{
            	Pan(Input.mousePosition - previousMousePosition.Value);
			}

            previousMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(mousePanButton))
        {
            StartGlide();
        }

		if (!Input.GetMouseButton(mousePanButton))
		{
			previousMousePosition = null;
		}

        Glide();
    }

    private void PanWithTouch()
    {
        if (Input.touchCount > 0)
        {
            EndGlide();
        }

        if (Input.touchCount == 1)
        {
            var touch = Input.touches.First();
            if (touch.phase == TouchPhase.Moved)
            {
                var delta = touch.deltaPosition;
                Pan(delta);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                StartGlide();
            }
        }

        Glide();
    }

    private void Glide()
    {
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

    private void StartGlide()
    {
        isGliding = true;
        glidedTime = 0;
    }

    private void Pan(Vector2 delta)
    {
        var d = (Vector3)(delta) * cam.orthographicSize / cam.pixelHeight * 2f;

        var c = d / Mathf.Sin(0.5f * Mathf.PI - Mathf.Deg2Rad * Vector3.Angle(cam.transform.up, Vector3.up));

        velocity = c.Constrain(constraint);

        cam.transform.position -= velocity;
    }

    private void EndGlide()
    {
        isGliding = false;
    }
}

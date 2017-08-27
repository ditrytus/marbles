using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LevelInOutEffect : MonoBehaviour {

	public Camera animatedCamera;
	public string defaultAnimatedCameraName = "Main Camera";

	public Camera frontCamera;
	public string defaultFrontCameraName = "FrontCamera";

	public Camera backCamera;
	public string defaultBackCameraName = "BackCamera";

	public Collider levelBoundary;
	public string defaultLevelBoundaryName = "Boundary";

	public float inDuration;

	public float outDuration;

	public FloatRange defaultNearPlane;

	private bool isAnimating = false;

	private enum InOutState
	{
		In,
		Out
	}

	private float startTime;

	private InOutState state;

	private float distanceBetweenCameras;

	private Vector3[] viewportPoints = new Vector3[]
	{
		new Vector3(0.0f, 0.0f),
		new Vector3(1.0f, 0.0f),
		new Vector3(0.0f, 1.0f),
		new Vector3(1.0f, 1.0f),
		new Vector3(0.5f, 0.5f)
	};
	
	void Start()
	{
		if (animatedCamera == null) animatedCamera = GameObject.Find(defaultAnimatedCameraName).GetComponent<Camera>();
		if (frontCamera == null) frontCamera = GameObject.Find(defaultFrontCameraName).GetComponent<Camera>();
		if (backCamera == null) backCamera = GameObject.Find(defaultBackCameraName).GetComponent<Camera>();
		if (levelBoundary == null) levelBoundary = GameObject.Find(defaultLevelBoundaryName).GetComponent<Collider>();

		var viewportMiddle = new Vector3(0.5f, 0.5f);
		distanceBetweenCameras = Vector3.Distance(
			frontCamera.ViewportToWorldPoint(viewportMiddle),
			backCamera.ViewportToWorldPoint(viewportMiddle));
	}

	public void GoIn()
	{
		AnimateToState(InOutState.In);
	}

	public void GoOut()
    {
        AnimateToState(InOutState.Out);
    }

    private void AnimateToState(InOutState newState)
    {
        state = newState;
        isAnimating = true;
        startTime = Time.time;
    }

    void Update ()
    {
		if (isAnimating)
		{
			var nearRange = GetNearRange();
            var t = (Time.time - startTime) / (state == InOutState.In ? inDuration : outDuration);
			var isOver = t >= 1.0;
			animatedCamera.nearClipPlane = !isOver ? Mathf.Lerp(
				state == InOutState.In ? nearRange.max : nearRange.min,
				state == InOutState.In ? nearRange.min : nearRange.max,
				t)
				: (state == InOutState.In ? defaultNearPlane.min : defaultNearPlane.max);
			if (isOver)
			{
				isAnimating = false;
			}
		}
    }

    private FloatRange GetNearRange()
    {
        return new FloatRange()
        {
            min = DistanceToClosestHit(frontCamera),
            max = distanceBetweenCameras - DistanceToClosestHit(backCamera)
        };
    }

    float DistanceToClosestHit(Camera cam)
	{
		return viewportPoints
			.Select(p => HitFromViewport(p, cam))
			.Where(h => h.HasValue)
			.Min(h => h.Value.distance);
	}

	RaycastHit? HitFromViewport(Vector3 viewportPoint, Camera cam)
	{
		RaycastHit hit;
		var ray = cam.ViewportPointToRay(viewportPoint);
		var isHit = levelBoundary.Raycast(ray, out hit, float.MaxValue);
		return isHit ? hit : (RaycastHit?)null;
	}
}

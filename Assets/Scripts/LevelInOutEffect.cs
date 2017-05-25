using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LevelInOutEffect : MonoBehaviour {

	public Camera animatedCamera;

	public Camera frontCamera;

	public Camera backCamera;

	public Collider levelBoundary;

	public float duration;

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
            var t = (Time.time - startTime) / duration;
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

	void OnDrawGizmos()
	{
		viewportPoints
			.Select(p => frontCamera.ViewportPointToRay(p))
			.ToList()
			.ForEach(r => Gizmos.DrawRay(r));
	}
}

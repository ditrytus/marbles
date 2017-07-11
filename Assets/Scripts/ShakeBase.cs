using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShakeBase : MonoBehaviour
{
    public float shakeTime;

	public float angleDeviation;

	public float shakeFactor = 1.0f;

	public GameObject shakedObject;

    public AxesFilter axesToShake = new AxesFilter(false, false, true);

	private bool isShaking;
	
	private float startTime;

	private Vector3 initialAngles;

    void Update ()
	{
        if (PausableTime.Instance.IsPaused)
		{
			return;
		}
        
		if (isShaking)
		{
			var deltaTime = PausableTime.Instance.Time - startTime;
			if (deltaTime >= shakeTime)
            {
                SetRotation(initialAngles);
				isShaking = false;
            }
            else
			{
				var t = (deltaTime / shakeTime);
                SetRotation(initialAngles.Add(Mathf.Cos(t * shakeFactor) * Mathf.Lerp(angleDeviation, 0.0f, t)));
			}
		}
	}

    private void SetRotation(Vector3 newAngles)
    {
        shakedObject.transform.localEulerAngles =
            newAngles.FilterCombine(initialAngles, axesToShake);
    }

    protected void StartShaking()
    {
        startTime = PausableTime.Instance.Time;
        initialAngles = shakedObject.transform.localEulerAngles;
        isShaking = true;
    }
}
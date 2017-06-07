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
		if (isShaking)
		{
			var deltaTime = Time.time - startTime;
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
        startTime = Time.time;
        initialAngles = shakedObject.transform.localEulerAngles;
        isShaking = true;
    }
}
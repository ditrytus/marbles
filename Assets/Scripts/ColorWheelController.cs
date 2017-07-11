using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheelController : MonoBehaviour
{
	public MarbleColor[] colors;

	public GameObject tokenPrototype;

	public float switchTime;

	public AxesFilter rotationAxis = new AxesFilter(false, false, true);

	private float startTime;

	private bool isSwitching;

	private Vector3 destinationAngle = Vector3.zero;

	private Vector3 currentAngle = Vector3.zero;

	private Vector3 previousAngle = Vector3.zero;

	private int currentColorIndex;

	private Vector3 originalAngles;

	public MarbleColor CurrentColor 
	{
		get
		{
			return colors[currentColorIndex];
		}
	}

	// Use this for initialization
	void Start ()
	{
		currentColorIndex = 0;
		originalAngles = transform.localEulerAngles;
		previousAngle = destinationAngle = transform.localEulerAngles.Filter(rotationAxis);
		Debug.Log("Z: " + transform.localEulerAngles.z);
		for (int i=0; i<colors.Length; i++)
		{
			var token = Instantiate(tokenPrototype, tokenPrototype.transform.position, tokenPrototype.transform.rotation, transform);
			token.Enable();
			var marbleColor = token.GetComponent<MarbleColorController>();
			marbleColor.SetColor(colors[i]);
			token.transform.RotateAround(transform.position, transform.InverseTransformDirection(rotationAxis.ToDirection()), GetAngleForIndex(i));
		}
	}

	public void Switch()
	{
		SetNewIndex((currentColorIndex + 1) % colors.Length);
	}

	private void SetNewIndex(int i)
	{
		isSwitching = true;
		previousAngle = currentAngle;
		destinationAngle -= GetAnglesForIndex(i - currentColorIndex);
		currentColorIndex = i;
		startTime = PausableTime.Instance.Time;
		
	}

	private Vector3 GetAnglesForIndex(int i)
    {
        var angle = GetAngleForIndex(i);
        return new Vector3(angle, angle, angle);
    }

    private float GetAngleForIndex(int i)
    {
        return (360.0f / colors.Length) * i;
    }

    // Update is called once per frame
    void Update ()
	{
		if (PausableTime.Instance.IsPaused)
		{
			return;
		}

		if (isSwitching)
        {
            var deltaTime = PausableTime.Instance.Time - startTime;
			if (deltaTime > switchTime)
			{
				SetRotation(destinationAngle);
				isSwitching = false;
			}
			else
			{
				var t = deltaTime / switchTime;
				var newAngles = new Vector3(
					Mathf.LerpAngle(previousAngle.x, destinationAngle.x, t),
					Mathf.LerpAngle(previousAngle.y, destinationAngle.y, t),
					Mathf.LerpAngle(previousAngle.z, destinationAngle.z, t)
				);
				SetRotation(newAngles);
			}
        }
    }

    private void SetRotation(Vector3 newAngles)
    {
		currentAngle = newAngles;
        transform.localRotation = Quaternion.Euler(newAngles.FilterCombine(originalAngles, rotationAxis));
    }
}

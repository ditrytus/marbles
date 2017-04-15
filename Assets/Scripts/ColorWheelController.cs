using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheelController : MonoBehaviour
{
	public MarbleColor[] colors;

	public GameObject tokenPrototype;

	public float switchTime;

	private float startTime;

	private bool isSwitching;

	private float destinationAngle = 0.0f;

	private float currentAngle = 0.0f;

	private float previousAngle = 0.0f;

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
		previousAngle = destinationAngle = transform.localEulerAngles.z;
		Debug.Log("Z: " + transform.localEulerAngles.z);
		for (int i=0; i<colors.Length; i++)
		{
			var token = Instantiate(tokenPrototype, tokenPrototype.transform.position, tokenPrototype.transform.rotation, transform);
			token.Enable();
			var marbleColor = token.GetComponent<MarbleColorController>();
			marbleColor.SetColor(colors[i]);
			token.transform.RotateAround(transform.position, transform.forward, GetAngleForIndex(i));
		}
	}

	public void NextColor()
	{
		SetNewIndex((currentColorIndex + 1) % colors.Length);
	}

	private void SetNewIndex(int i)
	{
		isSwitching = true;
		previousAngle = currentAngle;
		destinationAngle -= GetAngleForIndex(i - currentColorIndex);
		currentColorIndex = i;
		startTime = Time.time;
		
	}

	private float GetAngleForIndex(int i)
	{
		return (360.0f / colors.Length) * i;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isSwitching)
        {
            var deltaTime = Time.time - startTime;
			if (deltaTime > switchTime)
			{
				SetRotation(destinationAngle);
				isSwitching = false;
			}
			else
			{
                SetRotation(Mathf.LerpAngle(previousAngle, destinationAngle, deltaTime / switchTime));
			}
        }
    }

    private void SetRotation(float newAngle)
    {
		currentAngle = newAngle;
        transform.localRotation = Quaternion.Euler(
			originalAngles.x,
			originalAngles.y,
			newAngle);
    }
}

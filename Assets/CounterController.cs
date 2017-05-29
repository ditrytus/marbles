using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class CounterController : MonoBehaviour {

	private float unitAngle;

	public int unitBase = 10;

	public float unitDuration = 1.0f;

	public Transform[] cylinders;

	public int destinationValue = 0;

	private int currentValue;

	private bool isRotating = false;

	private Vector3[] angles;

	private float rotationStartTime;

	private int direction;

	public AxesFilter rotationAxes;

	void Start ()
	{
		currentValue = destinationValue;
		unitAngle = 360.0f / unitBase;

		angles = new Vector3[cylinders.Length];
		for (int i=0; i<angles.Length; i++)
		{
			angles[i] = cylinders[i].localEulerAngles;
		}
	}

	public void SetValue(int newValue)
    {
        destinationValue = newValue;
        StartRotating();
    }

    private void StartRotating()
    {
        if (destinationValue != currentValue)
        {
            isRotating = true;
            rotationStartTime = Time.time;
			direction = destinationValue > currentValue ? 1 : -1;
        }
    }

    void Update ()
	{
		if (isRotating)
		{
			var t = Time.time - rotationStartTime;
			for (int i=0; i<cylinders.Length; i++)
            {
				var isDigitChanging = GetDigit(i, currentValue) != GetDigit(i, currentValue + direction);
                if (isDigitChanging)
				{
					if (t < 1.0)
					{
						//cylinders[i].localEulerAngles = 
					}
				}
            }
        }
	}

    private float GetDigit(int i, int value)
    {
        return (value / Mathf.Pow(unitBase, i)) % unitBase;
    }
}

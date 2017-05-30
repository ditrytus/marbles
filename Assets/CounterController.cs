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

	public int currentValue;

	private bool isRotating = false;

	private Vector3[] angles;

	private float rotationStartTime;

	public int direction;

	public AxesFilter rotationAxes;

	void Start ()
	{
		currentValue = destinationValue;
		unitAngle = 360.0f / unitBase;

		angles = new Vector3[cylinders.Length];
		for (int i=0; i<angles.Length; i++)
		{
			angles[i] = cylinders[i].localRotation.eulerAngles;
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
			if (!isRotating)
			{
				isRotating = true;
				rotationStartTime = Time.time;
				direction = destinationValue > currentValue ? 1 : -1;
			}
        }
    }

    void Update ()
	{
		if (isRotating)
		{
			var t = (Time.time - rotationStartTime) / unitDuration;
			for (int i=0; i<cylinders.Length; i++)
            {
				var isDigitChanging = GetDigit(i, currentValue) != GetDigit(i, currentValue + direction);
                if (isDigitChanging)
				{
					float angleDelta = unitAngle * direction;
                    if (t < 1.0)
					{
                        var newAngles = new Vector3(
                            Mathf.Lerp(angles[i].x, angles[i].x + angleDelta, t),
                            Mathf.Lerp(angles[i].y, angles[i].y + angleDelta, t),
                            Mathf.Lerp(angles[i].z, angles[i].z + angleDelta, t)
						);
                        cylinders[i].localRotation = Quaternion.Euler(newAngles.FilterCombine(angles[i], rotationAxes));
					}
					else
					{
						var newAngles = new Vector3(
                            angles[i].x + angleDelta,
                            angles[i].y + angleDelta,
                            angles[i].z + angleDelta
						).FilterCombine(angles[i], rotationAxes);
                        cylinders[i].localRotation = Quaternion.Euler(newAngles);
						angles[i] = newAngles;
					}
				}
            }
			if (t>=1.0)
			{
				isRotating = false;
				currentValue = currentValue + direction;
				StartRotating();
			}
        }
	}

    private float GetDigit(int i, int value)
    {
        return (value / (int)Mathf.Pow(unitBase, i)) % unitBase;
    }
}

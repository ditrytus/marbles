using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class CounterController : MonoBehaviour {

	private float unitAngle;

	public int unitBase = 10;

	public float unitDurationUp = 1.0f;

	public float unitDurationDown = 1.0f;

	public Transform[] cylinders;

	public int destinationValue = 0;

	public IntReactiveProperty currentValue;

	private bool isRotating = false;

	private Vector3[] angles;

	private float rotationStartTime;

	private int direction;

	public AxesFilter rotationAxes;

	public IntRange valueRange = new IntRange(0, 99);

	void Start ()
	{
		currentValue = new IntReactiveProperty(destinationValue);

		unitAngle = 360.0f / unitBase;

		angles = new Vector3[cylinders.Length];
		for (int i=0; i<angles.Length; i++)
		{
			angles[i] = cylinders[i].localRotation.eulerAngles;
		}
	}

	public void SetValue(int newValue)
    {
		Debug.Log("New counter value: " + newValue);
        destinationValue = valueRange.Clamp(newValue);
        StartRotating();
    }

    private void StartRotating()
    {
        if (destinationValue != currentValue.Value)
        {
			if (!isRotating)
			{
				isRotating = true;
				rotationStartTime = Time.time;
				direction = destinationValue > currentValue.Value ? 1 : -1;
			}
        }
    }

    void Update ()
	{
		if (isRotating)
		{
			var t = (Time.time - rotationStartTime) / (direction > 0 ? unitDurationUp : unitDurationDown);
			for (int i=0; i<cylinders.Length; i++)
            {
				var isDigitChanging = GetDigit(i, currentValue.Value) != GetDigit(i, currentValue.Value + direction);
                if (isDigitChanging)
				{
					float angleDelta = - unitAngle * direction;
                    if (t < 1.0)
					{
                        var newAngles = new Vector3(
                            Mathf.Lerp(angles[i].x, angles[i].x + angleDelta, t),
                            Mathf.Lerp(angles[i].y, angles[i].y + angleDelta, t),
                            Mathf.Lerp(angles[i].z, angles[i].z + angleDelta, t)
						).FilterCombine(angles[i], rotationAxes);
                        cylinders[i].localRotation = Quaternion.Euler(newAngles);
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
				currentValue.SetValueAndForceNotify(currentValue.Value + direction);
				BroadcastMessage(CounterMessages.ValueChanged, currentValue.Value, SendMessageOptions.DontRequireReceiver);
				StartRotating();
			}
        }
	}

    private float GetDigit(int i, int value)
    {
        return (value / (int)Mathf.Pow(unitBase, i)) % unitBase;
    }
}

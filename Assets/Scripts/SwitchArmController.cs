using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SwitchArmController : MonoBehaviour {

	public float leftPositionAngle;

	public float rightPositionAngle;

	public float switchingDuration;

	public bool isLeft = true;

	private bool isSwitching = false;

	private float timeStarted;

	private GameObject lastMarble;

	void Start()
    {
        SetRotation(GetAngleForPosition());
    }

    private void SetRotation(float newZAngle)
    {
        transform.localEulerAngles = new Vector3(
			transform.localRotation.eulerAngles.x,
			transform.localRotation.eulerAngles.y,
			newZAngle);
    }

	void FixedUpdate()
	{
		if (isSwitching)
        {
            var currentTime = Time.time - timeStarted;
            var progress = currentTime / switchingDuration;

            var fromAngle = GetAngleForPosition();
            var toAngle = isLeft ? rightPositionAngle : leftPositionAngle;

            if (currentTime < switchingDuration)
            {
                SetRotation(Mathf.LerpAngle(fromAngle, toAngle, progress));
            }
            else
            {
                SetRotation(toAngle);
                isSwitching = false;
                isLeft = !isLeft;
            }
        }
    }

    private float GetAngleForPosition()
    {
        return isLeft ? leftPositionAngle : rightPositionAngle;
    }

    void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject != lastMarble && collision.gameObject.CompareTag("Marble") && !isSwitching)
		{
			isSwitching = true;
			timeStarted = Time.time;
			lastMarble = collision.gameObject;
		}
	}
}

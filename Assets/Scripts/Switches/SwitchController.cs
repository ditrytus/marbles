using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SwitchController : MonoBehaviour {

	public float leftPositionAngle;

	public float rightPositionAngle;

	public float switchingDuration;

	public bool isLeft = true;

	public bool isSwitching = false;
    
    public Vector3 rotationAxis;

    public float initialAngle = 0.0f;

    private Quaternion initialRotation;

	private float timeStarted;

    public AudioSource audioSource;

	void Start()
    {
        this.SetDefaultFromThis(ref audioSource);
        initialRotation = transform.localRotation;
        SetRotation(GetAngleForPosition());
    }

    private void SetRotation(float newAngle)
    {
        transform.localRotation = initialRotation * Quaternion.AngleAxis(initialAngle - newAngle, rotationAxis);
    }

	void FixedUpdate()
	{
        if (PausableTime.Instance.IsPaused)
        {
            return;
        }

		if (isSwitching)
        {
            var currentTime = PausableTime.Instance.Time - timeStarted;
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

    public void Switch()
    {
        if (!this.isSwitching)
        {
            isSwitching = true;
            timeStarted = PausableTime.Instance.Time;
            if (audioSource != null) audioSource.Play();
        }
    }
}

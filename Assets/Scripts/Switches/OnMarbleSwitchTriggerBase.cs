using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public abstract class OnMarbleSwitchTriggerBase : SwitchTriggerBase
{
	private GameObject lastMarble;

    public float lastMarbleTimeout = 3.0f;

    public float lastTriggeredTime;

	protected void SwitchWithObject(GameObject triggeringObject)
    {
        if ((
                triggeringObject != lastMarble
                || (PausableTime.Instance.Time - lastTriggeredTime) >= lastMarbleTimeout
            )
            && triggeringObject.CompareTag(Tags.Marble))
        {
            lastTriggeredTime = PausableTime.Instance.Time;
            lastMarble = triggeringObject;
            Trigger();
        }
    }
}

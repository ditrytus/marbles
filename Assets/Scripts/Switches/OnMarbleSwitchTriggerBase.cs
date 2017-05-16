using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public abstract class OnMarbleSwitchTriggerBase : SwitchTriggerBase
{
	private GameObject lastMarble;

	protected void SwitchWithObject(GameObject triggeringObject)
    {
        if (triggeringObject != lastMarble && triggeringObject.CompareTag(Tags.Marble))
        {
            Trigger();

            lastMarble = triggeringObject;
        }
    }

    
}

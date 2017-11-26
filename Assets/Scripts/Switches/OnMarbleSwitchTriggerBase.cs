using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public abstract class OnMarbleSwitchTriggerBase : SwitchTriggerBase
{
	private GameObject lastMarble;

    public float lastMarbleTimeout = 3.0f;

	protected void SwitchWithObject(GameObject triggeringObject)
    {
        if (triggeringObject != lastMarble && triggeringObject.CompareTag(Tags.Marble))
        {
            Trigger();

            StopAllCoroutines();
            lastMarble = triggeringObject;
            StartCoroutine(MarbleTimeout());
        }
    }

    IEnumerator MarbleTimeout()
    {
        yield return new WaitForSecondsRealtime(lastMarbleTimeout);
        lastMarble = null;
        yield break;
    }
}

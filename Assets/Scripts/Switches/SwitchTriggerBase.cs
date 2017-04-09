using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public abstract class SwitchTriggerBase : MonoBehaviour {

	public SwitchController switchController;

    public float delay = 0.0f;

	private GameObject lastMarble;

	protected void SwitchOnCollision(GameObject triggeringObject)
    {
        if (triggeringObject != lastMarble && triggeringObject.CompareTag("Marble") && !switchController.isSwitching)
        {
            if (delay == 0.0f)
            {
                switchController.Switch();
            }
            else
            {
                Observable.Timer(TimeSpan.FromSeconds(delay))
                    .Subscribe(_ => switchController.Switch());
            }
            
            lastMarble = triggeringObject;
        }
    }
}

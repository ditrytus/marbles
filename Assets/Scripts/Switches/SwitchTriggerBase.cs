﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public abstract class SwitchTriggerBase : MonoBehaviour {

	public GameObject switchController;

    public float delay = 0.0f;

	private GameObject lastMarble;

	protected void SwitchWithObject(GameObject triggeringObject)
    {
        if (triggeringObject != lastMarble && triggeringObject.CompareTag(Tags.Marble))
        {
            if (delay == 0.0f)
            {
                switchController.SendMessage(SwitchMessages.Switch);
            }
            else
            {
                Observable.Timer(TimeSpan.FromSeconds(delay))
                    .Subscribe(_ => switchController.SendMessage(SwitchMessages.Switch));
            }
            
            lastMarble = triggeringObject;
        }
    }
}

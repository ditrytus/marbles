using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwitchTriggerBase : MonoBehaviour {

	public SwitchController switchController;

	private GameObject lastMarble;

	protected void SwitchOnCollision(GameObject triggeringObject)
    {
        if (triggeringObject != lastMarble && triggeringObject.CompareTag("Marble") && !switchController.isSwitching)
        {
            switchController.Switch();
            lastMarble = triggeringObject;
        }
    }
}

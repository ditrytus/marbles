using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerExitSwitchTrigger : SwitchTriggerBase {

	void OnTriggerExit(Collider other)
    {
        SwitchWithObject(other.gameObject);
    }  
}

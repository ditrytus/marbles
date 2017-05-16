using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterSwitchTrigger : OnMarbleSwitchTriggerBase
{
	void OnTriggerEnter(Collider other)
    {
        SwitchWithObject(other.gameObject);
    }
}

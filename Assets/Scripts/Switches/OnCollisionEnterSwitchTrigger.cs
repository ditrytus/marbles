using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterSwitchTrigger : OnMarbleSwitchTriggerBase 
{
	void OnCollisionEnter(Collision collision)
    {
        SwitchWithObject(collision.gameObject);
    }    
}

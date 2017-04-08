using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterSwitchTrigger : SwitchTriggerBase
{
	void OnCollisionEnter(Collision collision)
    {
        SwitchOnCollision(collision.gameObject);
    }    
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterSwitchTrigger : SwitchTriggerBase {

	void OnTriggerEnter(Collider other)
    {
        SwitchOnCollision(other.gameObject);
    }  
}

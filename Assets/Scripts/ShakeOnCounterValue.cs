using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnCounterValue : ShakeOnEnter {

	public int triggerValue = 0;

	public void CounterValueChanged(int newValue)
	{
		if (newValue == triggerValue)
		{
			StartShaking();
		}
	}
}

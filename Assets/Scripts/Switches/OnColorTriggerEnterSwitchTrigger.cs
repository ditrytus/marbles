using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColorTriggerEnterSwitchTrigger : OnMarbleSwitchTriggerBase
{
	public MarbleColorController colorController;

	void OnTriggerEnter(Collider other)
    {
		var otherColor = other.GetComponent<MarbleColorController>();
		if (otherColor != null && otherColor.color.ColorEquals(colorController.color))
		{
			SwitchWithObject(other.gameObject);
		}
    }
}

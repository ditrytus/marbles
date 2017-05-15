using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnColorTriggerEnter : SpawnAtWithTimeout {

	public MarbleColorController colorController;

	void OnTriggerEnter(Collider other)
	{
		var otherColorController = other.GetComponent<MarbleColorController>();
		if (otherColorController != null && otherColorController.color.ColorEquals(colorController.color))
		{
			Spawn();	
		}
	}
}

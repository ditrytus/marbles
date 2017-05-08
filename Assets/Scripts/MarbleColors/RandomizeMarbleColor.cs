using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomizeMarbleColor : MarbleColorController {
	
	public MarbleColor[] colorBag;

	void Start ()
	{
		SetColor(colorBag[Random.Range(0, colorBag.Length)]);
	}
}

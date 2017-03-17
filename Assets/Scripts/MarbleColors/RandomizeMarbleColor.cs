using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomizeMarbleColor : MarbleColorController {
	void Start () {
		SetColor((MarbleColor)Random.Range(0, System.Enum.GetValues(typeof(MarbleColor)).Length));
	}
}

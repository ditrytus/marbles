using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomizeMarbleColor : MonoBehaviour {

	void Start () {
		var marbleColorController = GetComponent<MarbleColorController>();
		if (marbleColorController != null)	
		{
			marbleColorController.SetColor(
				(MarbleColor)Random.Range(0, System.Enum.GetValues(typeof(MarbleColor)).Length));
		}	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMarbleColorToWheel : MonoBehaviour {

	public MarbleColorController marbleColorController;

	private ColorWheelController colorWheelController;
	
	void Start()
	{
		colorWheelController = GetComponent<ColorWheelController>();
		Switch();
	}

	// Update is called once per frame
	public void Switch()
	{
		marbleColorController.SetColor(colorWheelController.CurrentColor);	
	}
}

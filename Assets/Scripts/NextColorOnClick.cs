using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextColorOnClick : MonoBehaviour {

	public ColorWheelController colorWheel;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			colorWheel.NextColor();
		}	
	}
}

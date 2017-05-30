using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementOnButton : MonoBehaviour {

	public CounterController counterController;

	public KeyCode increaseKey;

	public KeyCode decreaseKey;

	public int step = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(increaseKey))
		{
			counterController.SetValue(counterController.destinationValue + step);
		}
		if (Input.GetKeyDown(decreaseKey))
		{
			counterController.SetValue(counterController.destinationValue - step);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementOnButton : MonoBehaviour {

	public CounterController counterController;

	public KeyCode increaseKey;

	public KeyCode decreaseKey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(increaseKey))
		{
			counterController.SetValue(counterController.destinationValue + 1);
		}
		if (Input.GetKeyDown(decreaseKey))
		{
			counterController.SetValue(counterController.destinationValue - 1);
		}
	}
}

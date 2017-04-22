using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnClick : MonoBehaviour {

	public GameObject switchController;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			switchController.SendMessage(SwitchMessages.Switch);
		}	
	}
}

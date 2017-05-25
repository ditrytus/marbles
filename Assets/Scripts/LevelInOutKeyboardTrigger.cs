using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInOutKeyboardTrigger : MonoBehaviour {

	public LevelInOutEffect levelInOutEffect;

	public KeyCode inKey = KeyCode.Return;

	public KeyCode outKey = KeyCode.Escape;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(inKey))
		{
			levelInOutEffect.GoIn();
		}
		else if (Input.GetKeyDown(outKey))
		{
			levelInOutEffect.GoOut();
		}
	}
}

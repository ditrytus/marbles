using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorTriggerOnKey : MonoBehaviour {

	public Animator animator;

	public KeyCode key;

	public string triggerName;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(key))
		{
			animator.SetTrigger(triggerName);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorTrigger : MonoBehaviour {

	public Animator animator;

	public string triggerName;

	public void SetTrigger()
	{
		Debug.Log(triggerName);
		animator.SetTrigger(triggerName);
	}
}

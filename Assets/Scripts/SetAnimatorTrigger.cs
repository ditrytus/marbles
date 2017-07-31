using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorTrigger : MonoBehaviour {

	public Animator animator;

	public string triggerName;

	public void SetTrigger()
	{
		animator.SetTrigger(triggerName);
	}
}

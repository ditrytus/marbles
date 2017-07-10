using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMenuItemController : MonoBehaviour
{
	public Animator animator;

	public void OnToggle()
	{
		var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.IsName(CollapsibleStates.Closed))
		{
			animator.SetTrigger(CollapsibleStates.Triggers.Open);
		}
		else if (stateInfo.IsName(CollapsibleStates.Opened))
		{
			animator.SetTrigger(CollapsibleStates.Triggers.Close);
		}
	}
}

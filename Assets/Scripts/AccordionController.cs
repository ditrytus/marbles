using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccordionController : MonoBehaviour
{
	public Animator[] collapsibles;

	public void OnCollapsibleOpen()
	{
		foreach(var collapsible in collapsibles)
		{
			var state = collapsible.GetCurrentAnimatorStateInfo(0);
			if (state.IsName(CollapsibleStates.Opened))
			{
				collapsible.SetTrigger(CollapsibleStates.Triggers.Close);
			}
		}
	}
}

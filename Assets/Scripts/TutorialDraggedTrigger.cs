using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDraggedTrigger : MonoBehaviour
{
	public TutorialController tutorialController;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(Tags.Marble))
		{
			tutorialController.Dragged();
		}	
	}
}

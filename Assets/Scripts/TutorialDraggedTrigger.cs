using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDraggedTrigger : MonoBehaviour
{
	public TutorialController tutorialController;
	
	void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag(Tags.Marble))
		{
			tutorialController.Dragged();
		}	
	}
}

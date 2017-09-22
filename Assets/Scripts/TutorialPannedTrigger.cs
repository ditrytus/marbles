using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPannedTrigger : MonoBehaviour
{
	public TutorialController tutorialController;

	void Update ()
	{
		if (this.transform.position.y < 5)
		{
			tutorialController.Panned();
		}
	}
}

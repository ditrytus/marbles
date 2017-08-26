using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonsStatusesController : MonoBehaviour {

	public int unlockedLevels = 1;

	void Start ()
	{
		for(var i=0; i<transform.childCount; i++)
		{
			var levelButton = transform.GetChild(i);
			var levelNumber = levelButton.GetComponent<LevelNumber>().LevelNum;
			var buttonStatus = levelButton.GetComponent<LevelButtonStatusController>();
			
			if (levelNumber < unlockedLevels)
			{
				buttonStatus.SetButtonState(LevelButtonState.Unlocked);
			}
			else if (levelNumber == unlockedLevels)
			{
				buttonStatus.SetButtonState(LevelButtonState.Hidden);
			}
			else if (levelNumber > unlockedLevels)
			{
				buttonStatus.SetButtonState(LevelButtonState.Locked);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSceneButtonHandler : MonoBehaviour
{
	public Animator animator;

	public string nextSceneName;

	public LevelCompletedController levelCompletedController;

	public string triggerName = "Exit";

	public void OnClick()
	{
		Debug.Log("Go to scene: " + triggerName);
		levelCompletedController.nextSceneName = nextSceneName;
		animator.SetTrigger(triggerName);
	}
}
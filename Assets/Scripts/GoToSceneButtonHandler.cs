using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneButtonHandler : MonoBehaviour
{
	public Animator animator;

	public string nextSceneName;

	public LevelCompletedController levelCompletedController;

	public string triggerName = "Exit";

	public void DefaultOnClick()
	{
		OnClick(nextSceneName);
	}

	public void OnClick(string sceneName)
	{
		levelCompletedController.nextSceneName = sceneName;
		animator.SetTrigger(triggerName);
	}

	public void RestartOnClick()
	{
		OnClick(SceneManager.GetActiveScene().name);		
	}
}
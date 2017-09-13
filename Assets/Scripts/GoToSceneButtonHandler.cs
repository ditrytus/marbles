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

	public AudioSource audioSource;

	public AudioClip audioClip;

	void Start()
	{
		this.SetDefaultFromThis(ref audioSource);
	}

	public void DefaultOnClick()
	{
		OnClick(nextSceneName);
	}

	public void OnClick(string sceneName)
	{
		audioSource.PlayOneShot(audioClip);
		levelCompletedController.nextSceneName = sceneName;
		animator.SetTrigger(triggerName);
	}

	public void RestartOnClick()
	{
		OnClick(SceneManager.GetActiveScene().name);		
	}
}
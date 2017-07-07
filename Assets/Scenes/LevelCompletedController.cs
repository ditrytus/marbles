using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedController : MonoBehaviour
{
	public string nextSceneName;
	
	public void GoToNextScene()
	{
		SceneManager.LoadScene(nextSceneName);
	}
}

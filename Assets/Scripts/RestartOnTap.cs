using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnTap : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).tapCount == 1)
		{
			SceneManager.LoadScene(0);
		}
	}
}

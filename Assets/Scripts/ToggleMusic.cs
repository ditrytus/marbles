using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour {

	public AudioSource audioSource;

	public string defaultSourceGameObjectName;

	public Toggle toggle;

	void Start ()
	{
		this.SetDefaultFromName(ref audioSource, defaultSourceGameObjectName);
		this.SetDefaultFromThis(ref toggle);
	}
	
	public void Toggle ()
	{
		if (toggle.isOn)
		{
			Debug.Log("UnPause");
			audioSource.UnPause();
		}
		else
		{
			Debug.Log("Pause");			
			audioSource.Pause();
		}
	}
}

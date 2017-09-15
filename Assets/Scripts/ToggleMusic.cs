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
		toggle.onValueChanged.AddListener(OnValueChanged);
	}
	
	public void OnValueChanged(bool value)
	{
		if (value)
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

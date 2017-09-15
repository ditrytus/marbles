using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleSound : MonoBehaviour
{
	private float originalVolume;

	public Toggle toggle;

	public void Start()
	{
		this.SetDefaultFromThis(ref toggle);
		toggle.onValueChanged.AddListener(OnValueChanged);
	}

	public void OnValueChanged(bool value)
	{
		if (value)
		{
			Debug.Log("Unmute " + originalVolume);
			AudioListener.volume = originalVolume;
		}
		else
		{
			originalVolume = AudioListener.volume;
			Debug.Log("Mute " + originalVolume);			
			AudioListener.volume = 0;
		}
	}
}

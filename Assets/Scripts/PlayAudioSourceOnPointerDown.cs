using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayAudioSourceOnPointerDown : MonoBehaviour
{
	public AudioSource audioSource;

	void Start ()
	{
		this.SetDefaultFromThis(ref audioSource);
	}
	
	public void ButtonDown()
    {
		Debug.Log("ButtonDown Received");
		audioSource.Play();
	}
}

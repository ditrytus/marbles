using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSource : MonoBehaviour
{
	public AudioSource audioSource;

	void Start ()
	{
		this.SetDefaultFromThis(ref audioSource);	
	}

	public void Play()
	{
		this.audioSource.Play();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSoundBase : MonoBehaviour {

	public AudioSource audioSource;

	public AudioClip[] clips;

	protected virtual void Start()
	{
		this.SetDefaultFromThis(ref audioSource);
	}

	protected void PlayRandomSound(float volume)
	{
		audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)], volume);
	}
}

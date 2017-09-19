using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomClipOnStart : MonoBehaviour {

	public AudioSource audioSource;

	public AudioClip[] clips;

	void Start()
	{
		this.SetDefaultFromThis(ref audioSource);
		audioSource.clip = clips[Random.Range(0, clips.Length)];
	}
}

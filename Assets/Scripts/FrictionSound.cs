using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionSound : MonoBehaviour
{
	public AudioSource audioSource;

	public string tagFilter;

	private bool isCollision;

	private bool playsSound = false;
	
	void Start()
	{
		if (audioSource == null) audioSource = this.gameObject.GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (!other.gameObject.CompareTag(tagFilter))
		{
			return;
		}

		isCollision = true;
	}

	void Update()
	{
		if (isCollision && !playsSound)
		{
			playsSound = true;
			audioSource.Play();
		}
		if (!isCollision && playsSound)
		{
			playsSound = false;
			audioSource.Stop();
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (!other.gameObject.CompareTag(tagFilter))
		{
			return;
		}

		isCollision = false;
	}

	void OnCollisionStay(Collision other)
	{
		if (!other.gameObject.CompareTag(tagFilter))
		{
			return;
		}

		if (!isCollision)
		{
			isCollision = true;			
		}
	}
}

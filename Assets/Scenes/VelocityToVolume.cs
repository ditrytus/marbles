using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityToVolume : MonoBehaviour
{
	public AudioSource audioSource;

	public FloatRange velocityRange = new FloatRange(){min = 0.0f, max = 1.0f};

	public float vanishingIndex = 2.0f;

	public float volumeFactor = 1.0f;

	private Rigidbody body;

	// Use this for initialization
	void Start ()
	{
		if (audioSource == null) audioSource = this.gameObject.GetComponent<AudioSource>();
		body = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		var v = body.velocity.magnitude;
		var t = velocityRange.Lerpify(v);
		var volume = Mathf.Pow(Mathf.Clamp(Mathf.Lerp(0.0f, 1.0f, t), 0.0f, 1.0f), vanishingIndex) * volumeFactor;

		audioSource.volume = volume;
	}
}

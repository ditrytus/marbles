using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSoundOnCollision : PlayRandomSoundBase
{
	public FloatRange velocityRange = new FloatRange(){min = 0.0f, max = 1.0f};

	public float vanishingIndex = 2.0f;

	public float volumeFactor = 1.0f;

	public string tagFilter;

	private Rigidbody body;

	protected override void Start ()
	{
		base.Start();
		body = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (clips.Length == 0)
		{
			return;
		}

		if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter))
		{
			return;
		}

		var v = other.relativeVelocity.magnitude;
		var t = velocityRange.Lerpify(v);
		var volume = Mathf.Pow(Mathf.Clamp(Mathf.Lerp(0.0f, 1.0f, t), 0.0f, 1.0f), vanishingIndex) * volumeFactor;

		PlayRandomSound(volume);
	}
}

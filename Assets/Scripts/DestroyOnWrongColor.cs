using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class DestroyOnWrongColor : RxBehaviour {

	public float delay;

	public FloatRange radiusRange;

	public float wiggleTime;

	private bool isDestroying = false;

	private float startTime;

	private RandomizePosition randomizePosition;

	public AudioSource audioSource;

	public VelocityToVolume velocityToVolume;

	public AudioClip wiggleSound;

	public float volume = 1.0f;

	public void Start()
	{
		this.SetDefaultFromThis(ref audioSource);
		this.SetDefaultFromThis(ref velocityToVolume);
	}

	public void MarbleColorIsWrong()
	{
		if (isDestroying)
		{
			return;
		}
		isDestroying = true;

		var sub1 = Observable
			.Timer(TimeSpan.FromSeconds(delay), new PausableMainThreadScheduler())
			.Subscribe(_ => {
				GetComponent<Rigidbody>().isKinematic = true;
				GetComponents<Collider>().ToList().ForEach(c => c.isTrigger = true);

				if (velocityToVolume != null) velocityToVolume.enabled = false;
				audioSource.volume = volume;
				audioSource.PlayOneShot(wiggleSound);

				startTime = PausableTime.Instance.Time;

				randomizePosition = gameObject.AddComponent<RandomizePosition>();
				randomizePosition.radius = 0.0f;

				var sub2 = Observable.EveryUpdate()
					.Subscribe(__ => {
						randomizePosition.radius = Mathf.Lerp(
							radiusRange.min,
							radiusRange.max,
							(PausableTime.Instance.Time - startTime) / wiggleTime);
					});

				Observable
					.Timer(TimeSpan.FromSeconds(wiggleTime), new PausableMainThreadScheduler())
					.Subscribe(__ => {
						this.SendMessage(MarbleMessages.ExplodeMarble);
					});

				AddSubscriptions(sub2);
			});

		AddSubscriptions(sub1);
	}
}

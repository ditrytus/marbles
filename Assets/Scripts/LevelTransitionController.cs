using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UniRx;
using UniRx.Operators;

public class LevelTransitionController : RxBehaviour
{
	public Animator animator;

	public ProgressController progressController;

	public TimeSpeedController timeSpeedController;
	public string timeSpeedControllerObjectName = "FastForward Button";

	public string triggerName = "Complete";

	public float exitDelay;

	public AudioSource audioSource;

	void Start ()
	{
		if (progressController == null) progressController = GetComponent<ProgressController>();
		if (timeSpeedController == null) timeSpeedController = GameObject
			.Find(timeSpeedControllerObjectName)
			.GetComponent<TimeSpeedController>();
		this.SetDefaultFromThis(ref audioSource);

		var sub1 = 
			Observable.CombineLatest(
				FindObjectsOfType<CollectorController>()
				.Where(cc => cc.Countdown)
				.Select(c => c.counter.currentValue).ToArray())
			.Where(counts =>
			{
				Debug.Log(string.Join(", ", counts.Select(c => c.ToString()).ToArray()));
				return counts.All(count => count == 0);
			})
			.Skip(1)
			.AsUnitObservable()
			.Delay(
				TimeSpan.FromSeconds(exitDelay),
				new PausableMainThreadScheduler())
			.Subscribe(_ =>
			{
				Debug.Log("Triggered " + triggerName);
				progressController.CompletedLevel(LevelNameHelper.GetCurrentLevelNumber());
				timeSpeedController.OnPointerUp(null);
				animator.SetTrigger(triggerName);
				audioSource.Play();
			});

		AddSubscriptions(sub1);
	}
}

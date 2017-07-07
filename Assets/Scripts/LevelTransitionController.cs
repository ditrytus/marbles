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

	public string triggerName = "Complete";

	public float exitDelay;

	void Start ()
	{
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
			.Delay(TimeSpan.FromSeconds(exitDelay))
			.Subscribe(_ =>
			{
				Debug.Log("Triggered " + triggerName);
				animator.SetTrigger(triggerName);
			});

		AddSubscriptions(sub1);
	}
}

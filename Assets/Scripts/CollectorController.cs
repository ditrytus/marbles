using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CollectorController : RxBehaviour {

	public CounterController counter;

	public ContainerController container;

	public int RequiredCount = 10;

	public bool Countdown = true;

	public float delay = 0.5f;

	void Start ()
	{
		var sub1 = container.content.ObserveCountChanged(true)
			.Delay(TimeSpan.FromSeconds(delay))
			.Select(c => Countdown ? RequiredCount - c : c)
			.Subscribe(c => {
				counter.SetValue(c);
			});
		
		AddSubscriptions(sub1);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CollectorController : RxBehaviour {

	public CounterController counter;

	public ContainerController container;

	
	public int RequiredCount = 10;

	void Start ()
	{
		var sub1 = container.content.ObserveCountChanged(true)
			.Delay(TimeSpan.FromMilliseconds(500))
			.Select(c => RequiredCount - c)
			.Subscribe(c => {
				counter.SetValue(c);
			});
		
		AddSubscriptions(sub1);
	}
}

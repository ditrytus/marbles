using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class EnableOnAnyContainerCount : RxBehaviour
{
	public int triggerCount;

	public ContainerController[] containers;

	public GameObject objectToEnable;
	public string defaultObjectToEnableName = "Restart Hint";

	void Start ()
	{
		if (objectToEnable == null) objectToEnable = GameObject.Find(defaultObjectToEnableName);
		
		var triggeringCounts = Observable.CombineLatest(
			containers.Select(container =>
				container.content.ObserveCountChanged()));

		var sub1 = triggeringCounts
			.Where(counts => counts.Any(count => count == triggerCount))
			.Subscribe(c => {
				objectToEnable.Enable();
			});

		var sub2 = triggeringCounts
			.Where(counts => counts.All(count => count != triggerCount))
			.Subscribe(c => {
				objectToEnable.Disable();
			});

		AddSubscriptions(sub1, sub2);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnableOnContainerCount : RxBehaviour
{
	public int triggerCount;

	public ContainerController container;

	public GameObject objectToEnable;

	void Start ()
	{
		var sub1 = container.content.ObserveCountChanged()
			.Where(c => c == triggerCount)
			.Subscribe(c => {
				objectToEnable.Enable();
			});

		var sub2 = container.content.ObserveCountChanged()
			.Where(c => c != triggerCount)
			.Subscribe(c => {
				objectToEnable.Disable();
			});

		AddSubscriptions(sub1, sub2);
	}
}

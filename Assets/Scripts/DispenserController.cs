using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DispenserController : RxBehaviour
{
	public SpawnOnInterval trigger;

	public GameObject objectToDisable;

	void Start () {
		var sub1  = trigger.SpawningFinished.Subscribe(_ => {
			objectToDisable.Disable();
		});

		AddSubscriptions(sub1);
	}
}

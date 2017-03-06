using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FaceAt : RxBehaviour {

	public Transform observedObject;

	void Start () {
		var sub1 = Observable.EveryUpdate()
			.Subscribe(_ => {
				this.transform.LookAt(observedObject);
				this.transform.forward = -this.transform.forward;
			});

		AddSubscriptions(sub1);
	}
}

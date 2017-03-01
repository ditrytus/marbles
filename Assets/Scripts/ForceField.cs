using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ForceField : RxBehaviour {
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		this.OnTriggerStayAsObservable()
			.Subscribe(x => {
				var body = x.GetComponent<Rigidbody>();
				body.AddForce(direction, ForceMode.Force);
			});
	}
}

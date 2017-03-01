using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ContainerController : RxBehaviour {

	public List<GameObject> content;

	void Start () {
		content = new List<GameObject>();

		var sub1 = this.OnTriggerEnterAsObservable()
			.Subscribe(x => {
				content.Add(x.gameObject);
				Debug.Log(string.Format("Object {0} added to container {1}", x.gameObject, this.gameObject));
			});

		var sub2 = this.OnTriggerExitAsObservable()
			.Subscribe(x => {
				content.Remove(x.gameObject);
				Debug.Log(string.Format("Object {0} removed from container {1}", x.gameObject, this.gameObject));
			});

		AddSubscriptions(sub1, sub2);
	}
}

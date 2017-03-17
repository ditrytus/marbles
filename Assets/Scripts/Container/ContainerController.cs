using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ContainerController : RxBehaviour {

	public ReactiveCollection<GameObject> content = new ReactiveCollection<GameObject>();

	protected virtual IObservable<Collider> ProcessOnEnter(IObservable<Collider> onEnter)
	{
		return onEnter;
	}

	protected void Start ()
	{
		var sub1 = ProcessOnEnter(this.OnTriggerEnterAsObservable())
			.Subscribe(x => {
				content.Add(x.gameObject);
				Debug.Log(string.Format("Object {0} added to container {1}", x.gameObject, this.gameObject));
			});

		var sub2 = this.OnTriggerExitAsObservable()
			.Subscribe(x => {
				content.Remove(x.gameObject);
				Debug.Log(string.Format("Object {0} removed from container {1}", x.gameObject, this.gameObject));
			});

		AddSubscriptions(content, sub1, sub2);
	}
}

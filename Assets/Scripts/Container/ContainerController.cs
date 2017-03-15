using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ContainerController : RxBehaviour {

	public ReactiveCollection<GameObject> content = new ReactiveCollection<GameObject>();

	protected virtual IObservable<Collider> FilterOnEnter(IObservable<Collider> onEnter)
	{
		return onEnter;
	}

	void Start ()
	{
		var sub1 = FilterOnEnter(this.OnTriggerEnterAsObservable())
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

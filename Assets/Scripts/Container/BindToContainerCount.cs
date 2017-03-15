using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class BindToContainerCount : RxBehaviour {

	public ContainerController containerController;

	// Use this for initialization
	void Start () {
		var text = GetComponent<Text>();

		if (text == null)
		{
			throw new InvalidOperationException("There is no Text component attached.");
		}

		var sub1 = containerController.content
			.ObserveCountChanged()
			.SubscribeToText(text);

		AddSubscriptions(sub1);
	}
}

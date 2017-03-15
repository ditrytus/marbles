using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class BindToContainerCount : RxBehaviour {

	public ContainerController containerController;

	protected virtual IObservable<int> FilterCount(IObservable<int> count)
	{
		return count;
	}

	// Use this for initialization
	protected virtual void Start ()
    {
        var text = GetTextComponent();

        var sub1 = FilterCount(containerController.content.ObserveCountChanged())
            .SubscribeToText(text);

        AddSubscriptions(sub1);
    }

    protected Text GetTextComponent()
    {
        var text = GetComponent<Text>();

        if (text == null)
        {
            throw new InvalidOperationException("There is no Text component attached.");
        }

        return text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class ExplodeOnEnterContainer : ContainerController
{
	public FloatRange delayRange;

	public FloatRange wiggleTimeRange;

	protected override IObservable<Collider> ProcessOnEnter(IObservable<Collider> onEnter)
    {
        var sub1 = onEnter
            .Subscribe(c =>
			{
				var destComp = c.gameObject.GetComponent<DestroyOnWrongColor>();
				destComp.delay = UnityEngine.Random.Range(delayRange.min, delayRange.max);
				destComp.wiggleTime = UnityEngine.Random.Range(wiggleTimeRange.min, wiggleTimeRange.max);
				c.gameObject.SendMessage(MarbleColorFilteredContainer.MarbleColorIsWrong);
            });

        AddSubscriptions(sub1);

        return onEnter;
    }
}

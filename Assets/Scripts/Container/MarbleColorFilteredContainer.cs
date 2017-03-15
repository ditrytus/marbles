using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class MarbleColorFilteredContainer : ContainerController
{
    public MarbleColor marbleColor;

    protected override IObservable<Collider> FilterOnEnter(IObservable<Collider> onEnter)
    {
        return onEnter.Where(c => {
            var itemColor = c.gameObject.GetComponent<MarbleColorController>();
            return itemColor != null && itemColor.color == marbleColor;
        });
    }
}
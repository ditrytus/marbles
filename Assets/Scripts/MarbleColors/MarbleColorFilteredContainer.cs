using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class MarbleColorFilteredContainer : ContainerController
{
    public MarbleColor marbleColor;

    public static string MarbleColorIsWrong = "MarbleColorIsWrong";

    protected override IObservable<Collider> ProcessOnEnter(IObservable<Collider> onEnter)
    {
        var sub1 = onEnter.Where(IsMarbleOfOtherColor)
            .Subscribe(c => {
                c.gameObject.SendMessage(MarbleColorIsWrong);
            });

        AddSubscriptions(sub1);

        return onEnter.Where(IsMarbleOfColor);
    }

    private bool IsMarbleOfColor(Collider c)
    {
        var itemColor = c.gameObject.GetComponent<MarbleColorController>();
        return itemColor != null && itemColor.color == marbleColor;
    }

    private bool IsMarbleOfOtherColor(Collider c)
    {
        var itemColor = c.gameObject.GetComponent<MarbleColorController>();
        return itemColor != null && itemColor.color != marbleColor;
    }

    public void SetMarbleColor(MarbleColor color)
    {
        this.marbleColor = color;
    }
}
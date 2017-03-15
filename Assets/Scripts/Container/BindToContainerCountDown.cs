using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class BindToContainerCountDown : BindToContainerCount {

	public IntRange range;

	protected override void Start()
	{
		base.Start();
        GetTextComponent().text = AdjustCount(containerController.content.Count).ToString();
	}

	protected override IObservable<int> FilterCount(IObservable<int> count)
    {
        return count.Select(c => AdjustCount(c));
    }

    private int AdjustCount(int c)
    {
        return Math.Max(range.max - c, range.min);
    }
}

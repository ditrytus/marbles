using UnityEngine;
using System.Collections.Generic;
using System;

public class RxBehaviour : MonoBehaviour {
    private List<IDisposable> subscriptions = new List<IDisposable>();

    protected void AddSubscriptions(params IDisposable[] items)
    {
        subscriptions.AddRange(items);
    }

	protected void OnDestroy()
	{
		CancelSubscriptions();
	}

    protected void CancelSubscriptions()
    {
        subscriptions.ForEach(s => s.Dispose());
    }
}
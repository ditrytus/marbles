using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;

public class PausableMainThreadScheduler : Scheduler.MainThreadScheduler
{
	public override DateTimeOffset Now
	{
		get { return PausableTime.Instance.UtcNow; }
	}

	protected override IEnumerator DelayAction(TimeSpan dueTime, Action action, ICancelable cancellation)
	{
		if (dueTime == TimeSpan.Zero)
		{
			yield return null;
		}
		else
		{
			var startTime = Now;
			float elapsed = 0.0f;   
			float waitFor = 0.0f;
			do
			{
				elapsed = (float)(Now - startTime).TotalSeconds;
				waitFor = ((float)dueTime.TotalSeconds - elapsed) / PausableTime.Instance.TimeScale;
				yield return new WaitForSeconds(waitFor / 4.0f);
			} while (elapsed < dueTime.TotalSeconds);
		}

		if (cancellation.IsDisposed) yield break;
		MainThreadDispatcher.UnsafeSend(action);
	}
}

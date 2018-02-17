using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class PausableMainThreadScheduler : Scheduler.MainThreadScheduler
{
	public override DateTimeOffset Now
	{
		get { return PausableTime.Instance.UtcNow; }
	} 
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausableTime : IPausable
{
	public static PausableTime Instance { get; private set; }

	private static DateTimeOffset StartUtc;

	static PausableTime()
	{
		Instance = new PausableTime();
		StartUtc = DateTime.UtcNow;
	}

	public bool IsPaused { get; private set; }

	private float pauseTime = 0.0f;

	public float gapTime;

	public float Time
	{
		get
		{
			if (IsPaused)
			{
				return pauseTime;
			}

			return UnityEngine.Time.time - gapTime;
		}
	}

    public DateTimeOffset UtcNow
	{
		get
		{
			return StartUtc.AddSeconds(Time);
		}
	}

    public PausableTime()
	{
		IsPaused = false;
		gapTime = 0.0f;
	}

    public void Pause()
    {
        if (IsPaused)
		{
			return;
		}

		pauseTime = Time;

		IsPaused = true;
    }

    public void Resume()
    {
        if (!IsPaused)
		{
			return;
		}

		gapTime += UnityEngine.Time.time - pauseTime;

		IsPaused = false;
    }
}

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

	private float unscaledPauseTime = 0.0f;

	public float gapTime;

	public float unscaledGapTime;

	public float Time
	{
		get
		{
			float result;
			if (IsPaused)
			{
				result = pauseTime;
			}
			else
			{
				result =  UnityEngine.Time.time - gapTime;
			}
			
			return result;
		}
	}

	public float UnscaledTime
	{
		get
		{
			float result;
			if (IsPaused)
			{
				result = unscaledPauseTime;
			}
			else
			{
				result =  UnityEngine.Time.unscaledTime - unscaledGapTime;
			}
			
			return result;
		}
	}

    public DateTimeOffset UtcNow
	{
		get
		{
			return StartUtc.AddSeconds(Time);
		}
	}

	public DateTimeOffset UnscaledUtcNow
	{
		get
		{
			return StartUtc.AddSeconds(UnscaledTime);
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
		unscaledPauseTime = UnscaledTime;

		IsPaused = true;
    }

    public void Resume()
    {
        if (!IsPaused)
		{
			return;
		}

		gapTime = UnityEngine.Time.time - pauseTime;
		unscaledGapTime = UnityEngine.Time.unscaledTime - unscaledPauseTime;

		IsPaused = false;
    }
}

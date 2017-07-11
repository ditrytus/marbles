using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausableTime : IPausable
{
	public static PausableTime Instance { get; private set; }

	static PausableTime()
	{
		Instance = new PausableTime();
	}

	public bool IsPaused { get; private set; }

	private float pauseTime = 0.0f;

	public float gapTime;

	public float Time
	{
		get
		{
			return UnityEngine.Time.time - gapTime;
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

		pauseTime = UnityEngine.Time.time;

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

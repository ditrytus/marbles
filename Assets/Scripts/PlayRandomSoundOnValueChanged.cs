using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSoundOnValueChanged : PlayRandomSoundBase
{
	public float volume;

	private int previousValue;

	[Serializable]
	public enum ChangeDirection
	{
		Up,
		Down,
		Both
	}

	public ChangeDirection direction = ChangeDirection.Both;

	public void CounterValueChanged(int value)
	{
		if ((direction == ChangeDirection.Down && value < previousValue)
			|| (direction == ChangeDirection.Up && value > previousValue)
			|| (direction == ChangeDirection.Both))
		{
			PlayRandomSound(volume);
		}
		previousValue = value;
	}
}

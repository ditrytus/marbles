using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSoundOnValue : PlayRandomSoundBase {

	public int triggerValue = 0;

	public float volume = 1.0f;

	public void CounterValueChanged(int value)
	{
		if (triggerValue == value)
		{
			PlayRandomSound(volume);
		}
	}
}

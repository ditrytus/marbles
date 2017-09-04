using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSoundOnValueChanged : PlayRandomSoundBase
{
	public float volume;

	public void CounterValueChanged(int value)
	{
		PlayRandomSound(volume);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSoundOnStart : PlayRandomSoundBase
{
	protected override void Start ()
	{
		base.Start();
		PlayRandomSound(1.0f);
	}
}

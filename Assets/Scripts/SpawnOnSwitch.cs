using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnSwitch : SpawnAtWithTimeout
{
	public void Switch()
	{
		Spawn();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
	public static Vector3 Add(this Vector3 vector, float xyz)
	{
		return new Vector3(xyz, xyz, xyz) + vector;
	}
}

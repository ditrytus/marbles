using System;
using UnityEngine;

[Serializable]
public class AxesRanges
{
	public FloatRange xRange;
	public FloatRange yRange;
	public FloatRange zRange;

	public bool Contains(Vector3 vector)
	{
		return xRange.Contains(vector.x)
			&& yRange.Contains(vector.y)
			&& zRange.Contains(vector.z);
	}
}
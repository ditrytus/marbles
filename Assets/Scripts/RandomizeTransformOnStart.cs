using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeTransformOnStart : MonoBehaviour {

	public AxesRanges positionRange;

	public AxesRanges rotationEulerRange;
	
	public AxesRanges scaleRange;

	void Start ()
	{
		this.transform.position += new Vector3(
			Random.Range(positionRange.xRange.min, positionRange.xRange.max),
			Random.Range(positionRange.yRange.min, positionRange.yRange.max),
			Random.Range(positionRange.zRange.min, positionRange.zRange.max));

		this.transform.rotation *= Quaternion.Euler(
			Random.Range(rotationEulerRange.xRange.min, rotationEulerRange.xRange.max),
			Random.Range(rotationEulerRange.yRange.min, rotationEulerRange.yRange.max),
			Random.Range(rotationEulerRange.zRange.min, rotationEulerRange.zRange.max));

		this.transform.localScale += new Vector3(
			Random.Range(scaleRange.xRange.min, scaleRange.xRange.max),
			Random.Range(scaleRange.yRange.min, scaleRange.yRange.max),
			Random.Range(scaleRange.zRange.min, scaleRange.zRange.max));
	}
}

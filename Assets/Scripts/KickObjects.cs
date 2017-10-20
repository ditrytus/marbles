using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KickObjects : MonoBehaviour {

	public string objectsToKickTag;

	public float force = 1.0f;

	public void Kick()
	{
		var bodiesToKick = GameObject
			.FindGameObjectsWithTag(objectsToKickTag)
			.Select(obj => obj.GetComponent<Rigidbody>())
			.ToArray();

		foreach(var body in bodiesToKick)
		{
			body.AddForce(Random.onUnitSphere * force, ForceMode.Impulse);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeSleepingRigidbodies : MonoBehaviour {

	public float force;

	public bool randomDirection = false;

	void OnTriggerStay(Collider other)
	{
        if (other.attachedRigidbody.IsSleeping())
		{
			other.attachedRigidbody.AddForce((randomDirection ? Random.onUnitSphere : Vector3.up) * force);    
		}
    }
}

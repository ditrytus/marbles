using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeSleepingRigidbodies : MonoBehaviour {

	public float force;

	void OnTriggerStay(Collider other)
	{
        if (other.attachedRigidbody.IsSleeping())
		{
			other.attachedRigidbody.AddForce(Vector3.up * force);    
		}
    }
}

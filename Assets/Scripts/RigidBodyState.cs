using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyState
{
	public RigidBodyState(Rigidbody rigidbody)
		: this(
			rigidbody.velocity,
			rigidbody.angularVelocity,
			rigidbody.isKinematic)
	{
	}

	public static RigidBodyState Paused
	{
		get 
		{
			return new RigidBodyState(
				Vector3.zero,
				Vector3.zero,
				true
			);
		}
	}

	private RigidBodyState(
		Vector3 velocity,
		Vector3 angularVelocity,
		bool isKinematic)
	{
		Velocity = velocity;
		AngularVelocity = angularVelocity;
		IsKinematic = isKinematic;
	}

	public Vector3 Velocity { get; }

	public Vector3 AngularVelocity { get; }

	public bool IsKinematic { get; }

	public void Restore(Rigidbody rigidbody)
	{
		rigidbody.isKinematic = IsKinematic;
		rigidbody.AddForce(Velocity, ForceMode.VelocityChange);
		rigidbody.AddTorque(AngularVelocity, ForceMode.VelocityChange);
	}
}

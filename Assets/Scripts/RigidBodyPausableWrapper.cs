using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyPausableWrapper : IPausable
{
	private Rigidbody rigidbody;

	private RigidBodyState state;

	public RigidBodyPausableWrapper(Rigidbody rigidbody)
	{
		this.rigidbody = rigidbody;
	}

	private bool isPaused = false;

    public void Pause()
    {
        if (isPaused)
		{
			return;
		}

		state = new RigidBodyState(rigidbody);

		RigidBodyState.Paused.Restore(rigidbody);

		isPaused = true;
    }

    public void Resume()
    {
        if (!isPaused)
		{
			return;
		}

		state.Restore(rigidbody);

		isPaused = false;
    }
}

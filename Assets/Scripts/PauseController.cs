using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PauseController : MonoBehaviour, IPausable
{
	public GameObject[] objectsToDeactivate;

	private Dictionary<GameObject, bool> objectsStateToResume;

	public GameObject rootToPause;

	private RigidBodyPausableWrapper[] pausableBodies;

	private bool isPaused = false;

	private IPausable[] pausables;

    public bool IsPaused
	{
		get
		{
			return isPaused;
		}
	}

    void Start()
	{
		objectsStateToResume = objectsToDeactivate.ToDictionary(o => o, o => o.activeSelf);
	}

	public void Pause ()
	{
		if (isPaused)
		{
			return;
		}

		foreach(var obj in objectsToDeactivate)
		{
			objectsStateToResume[obj] = obj.activeSelf;
			obj.SetActive(false);
		}

		var rigidBodies = rootToPause.GetComponentsInChildren<Rigidbody>(true);

		pausableBodies = rigidBodies.Select(r => new RigidBodyPausableWrapper(r)).ToArray();

		foreach(var body in pausableBodies)
		{
			body.Pause();
		}

		pausables = rootToPause.GetComponentsInChildren<IPausable>(true);

		foreach(var pausable in pausables)
		{
			pausable.Pause();
		}

		isPaused = true;
	}

	public void Resume()
	{
		if (!isPaused)
		{
			return;
		}

		foreach(var obj in objectsStateToResume)
		{
			if (obj.Value)
			{
				obj.Key.SetActive(true);
			}
		}

		foreach(var body in pausableBodies)
		{
			body.Resume();
		}

		foreach(var pausable in pausables)
		{
			pausable.Resume();
		}

		isPaused = false;
	}
}
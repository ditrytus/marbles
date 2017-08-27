using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetDefaultPauseControllerObjects : MonoBehaviour {

	public PauseController pauseController;

	public string[] objectsToDeactivateNames = new string[0];

	public string[] rootsToPauseNames = new string[0];

	void Start ()
    {
        if (pauseController == null) pauseController = GetComponent<PauseController>();
		
        pauseController.objectsToDeactivate = ToGameObjects(objectsToDeactivateNames);
        pauseController.rootsToPause = ToGameObjects(rootsToPauseNames);
    }

    private GameObject[] ToGameObjects(string[] objectNames)
    {
        return objectNames
			.Select(name => GameObject.Find(name))
			.ToArray();
    }
}

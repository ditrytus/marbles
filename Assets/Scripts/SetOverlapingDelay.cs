using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetOverlapingDelay : MonoBehaviour
{
	public string defaultComponentsTag = "Dispenser";

	public float overlapTime = 0.0f;

	void Start()
	{
		var components = GameObject.FindGameObjectsWithTag(defaultComponentsTag)
			.Select(g => g.GetComponent<IDelayedInterval>())
			.ToArray();

		IDelayedInterval prevComponent = null;
		foreach (var component in components)
		{
			component.Delay =
				prevComponent != null
				? prevComponent.Delay + (prevComponent.Interval * prevComponent.MaxCount) - overlapTime
				: 0.0f;
			prevComponent = component;
		}

		
	}
}

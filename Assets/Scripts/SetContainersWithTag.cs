using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetContainersWithTag : MonoBehaviour
{
	public EnableOnAnyContainerCount enabler;

	public string tagName = Tags.DragSource;

	void Start ()
	{
		enabler.containers = GameObject
			.FindGameObjectsWithTag(tagName)
			.Select(go => go.GetComponent<ContainerController>())
			.Where(cc => cc != null)
			.ToArray();
	}
}

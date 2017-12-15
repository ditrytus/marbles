using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class TransformExtensions
{
	public static IEnumerable<Transform> GetChildren(this Transform transform)
	{
		return Enumerable
			.Range(0, transform.childCount - 1)
			.Select(i => transform.GetChild(i));
	}

	public static IEnumerable<GameObject> GetChildren(this GameObject gameObject)
	{
		return gameObject.transform
			.GetChildren()
			.Select(transform => transform.gameObject);
	}
}

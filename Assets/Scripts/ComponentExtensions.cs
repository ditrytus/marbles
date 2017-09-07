using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentExtensions
{
	public static void SetDefaultFromThis<TComponent>(this MonoBehaviour script, ref TComponent component) where TComponent : Component
	{
		if (component == null) component = script.gameObject.GetComponent<TComponent>();
	}
}

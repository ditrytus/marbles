using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionToRaycastHitOnMouseButtonDown : MonoBehaviour
{
	private const float MaxDistance = 100000.0f;
	public int mouseButton = 1;

	public Camera cam;

	public LayerMask layerMask;

	public QueryTriggerInteraction hitTrigger = QueryTriggerInteraction.Ignore;

	void Update ()
	{
		if (Input.GetMouseButtonDown(mouseButton))
		{
			var ray = cam.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, MaxDistance, layerMask.value, hitTrigger))
			{
				transform.position = hit.point;
			}
		}
	}
}

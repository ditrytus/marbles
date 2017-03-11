using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColliderDragAndDropDestination : MonoBehaviour, IDragAndDropDestination {

	public new Camera camera;

	public Collider acceptingCollider;

    public bool TryAccept(Vector2 position, GameObject draggedObject)
    {
		if (!this.enabled)
		{
			return false;
		}

		var acceptingLayer = acceptingCollider.gameObject.layer;

        var ray = camera.ScreenPointToRay(position);
		var hit = Physics.RaycastAll(ray, float.MaxValue)
			.Cast<RaycastHit?>()
			.SingleOrDefault(h => h.Value.collider == acceptingCollider);
		
		if (!hit.HasValue)
		{
			return false;
		}

		draggedObject.transform.position = hit.Value.point;
		draggedObject.layer = acceptingLayer;
		
		return true;
    }
}

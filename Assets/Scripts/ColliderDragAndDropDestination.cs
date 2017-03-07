using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColliderDragAndDropDestination : MonoBehaviour, IDragAndDropDestination {

	public Camera camera;

	public Collider acceptingCollider;

    public bool TryAccept(Touch touch, GameObject draggedObject)
    {
		var acceptingLayer = acceptingCollider.gameObject.layer;

        var ray = camera.ScreenPointToRay(touch.position);
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

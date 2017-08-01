using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColliderDragAndDropDestination : MonoBehaviour, IDragAndDropDestination {

	public Camera acceptingCamera;

	public string acceptingCameraTag;

	public Collider acceptingCollider;

	void Start()
	{
		if (acceptingCamera == null && !string.IsNullOrEmpty(acceptingCameraTag))
		{
			var cameraObject = GameObject.FindGameObjectWithTag(acceptingCameraTag);
			acceptingCamera = cameraObject.GetComponent<Camera>();
		}
	}

    public bool TryAccept(Vector2 position, GameObject draggedObject)
    {
		if (!this.enabled)
		{
			return false;
		}

		var acceptingLayer = acceptingCollider.gameObject.layer;

        var ray = acceptingCamera.ScreenPointToRay(position);
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

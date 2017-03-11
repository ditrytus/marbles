using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class ContainerDragAndDropSource : MonoBehaviour, IDragAndDropSource
{
	public Camera sourceCamera;
	
	public ContainerController container;

	public Collider dragAndDropCollider;

	public Transform returnPoint;

    public GameObject GetDraggedObject(Vector2 position)
    {
        var ray = sourceCamera.ScreenPointToRay(position);
		var hit = Physics.RaycastAll(ray, float.MaxValue)
			.Cast<RaycastHit?>()
			.SingleOrDefault(h => h.Value.collider == dragAndDropCollider);

		if (!hit.HasValue)
		{
			return null;
		};

		return container.content.FirstOrDefault();
    }

    public void RemoveObject(GameObject draggedObject)
    {
        container.content.Remove(draggedObject);
    }

    public void ReturnObject(GameObject draggedObject)
    {
        draggedObject.transform.position = returnPoint.position;
    }
}

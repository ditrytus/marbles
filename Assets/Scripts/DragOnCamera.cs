using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DragOnCamera : RxBehaviour {

	public Camera dragCamera;

	public DragAndDropController dragAndDropController;

	private GameObject draggedObject;

	private int originalLayer;
	
	void Start()
	{
		var sub1 = dragAndDropController.Phases
			.Where(p => p == DragAndDropPhase.Started)
			.Subscribe(p => {
				draggedObject = dragAndDropController.DraggedObject;

				originalLayer = draggedObject.layer;
				draggedObject.layer = dragCamera.gameObject.layer;
			});

		var sub2 = dragAndDropController.Phases
			.Where(p => p == DragAndDropPhase.Canceled)
			.Subscribe(p => {
				draggedObject.layer = originalLayer;
			});

		var sub3 = dragAndDropController.Phases
			.Where(p => p.IsOver())
			.Subscribe(_ => {
				draggedObject = null;
			});

		var sub4 = dragAndDropController.Moves
			.Subscribe(position => {
				var point = dragCamera.ScreenToViewportPoint(position);
				point.z = 5;
				if (draggedObject != null)
				{
					draggedObject.transform.position = dragCamera.ViewportToWorldPoint(point);
				}
			});

		AddSubscriptions(sub1, sub2, sub3, sub4);
	}
}

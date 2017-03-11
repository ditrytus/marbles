using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DragOnCamera : RxBehaviour {

	public new Camera camera;

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
				draggedObject.layer = camera.gameObject.layer;
			});

		var sub2 = dragAndDropController.Phases
			.Where(p => p == DragAndDropPhase.Canceled)
			.Subscribe(p => {
				draggedObject.layer = originalLayer;
			});

		var sub3 = dragAndDropController.Touches
			.Subscribe(touch => {
				var point = camera.ScreenToViewportPoint(touch.position);
				point.z = 5;
				draggedObject.transform.position = camera.ViewportToWorldPoint(point);
			});

		AddSubscriptions(sub1, sub2, sub3);
	}
}

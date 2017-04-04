using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System;

public class DisableOnDragAndDrop : RxBehaviour {

	public List<DragAndDropController> dragAndDropControllers = new List<DragAndDropController>();

	public List<GameObject> objectsToDisable = new List<GameObject>();

	private List<GameObject> objectsToEnable = new List<GameObject>();

	void Start () {
		var allPhases = dragAndDropControllers
			.Select(c => c.Phases)
			.Aggregate((phaseA, phaseB) => phaseA.Merge(phaseB));

		var sub1 = allPhases	
			.Where(p => p == DragAndDropPhase.Started)
			.Subscribe(_ => {
				objectsToEnable = objectsToDisable.Where(o => o.active).ToList();
				objectsToEnable.ForEach(o => o.Disable());
			});

		var sub2 = allPhases
			.Where(p => p.IsOver())
			.Subscribe(_ => {
				objectsToEnable.ForEach(o => o.Enable());
			});

		AddSubscriptions(sub1, sub2);
	}
}

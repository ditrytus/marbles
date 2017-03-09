using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MakeDraggedObjectKinematic : RxBehaviour {

	public DragAndDropController dragAndDropController;

	private bool wasBodyKinematic;
	private bool wasGravityUsed;

	void Start()
	{
		var sub1 = dragAndDropController.Phases
			.Where(p => p == DragAndDropPhase.Started)
			.Subscribe(p => {
				var body = dragAndDropController.DraggedObject.GetComponent<Rigidbody>();
				if (body!=null)
                {
                    SetBodyToKinematicWithoutGravity(body);
                }
            });

		var sub2 = dragAndDropController.Phases
			.Where(p => p.IsOver())
			.Subscribe(p => {
				var body = dragAndDropController.DraggedObject.GetComponent<Rigidbody>();
				if (body!=null)
                {
                    RestoreOriginalKinematicGravity(body);
                }
            });

		AddSubscriptions(sub1, sub2);
	}

    private void RestoreOriginalKinematicGravity(Rigidbody body)
    {
        body.isKinematic = wasBodyKinematic;
        body.useGravity = wasGravityUsed;
    }

    private void SetBodyToKinematicWithoutGravity(Rigidbody body)
    {
        wasBodyKinematic = body.isKinematic;
        wasGravityUsed = body.useGravity;

        body.isKinematic = true;
        body.useGravity = false;
    }
}

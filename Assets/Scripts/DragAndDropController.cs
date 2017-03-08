using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UniRx;
using System.Linq;

public class DragAndDropController : RxBehaviour
{
    public GameObject sourceObject;

    private IDragAndDropSource Source
    {
        get
        {
            return sourceObject.GetComponent<IDragAndDropSource>();
        }
    }

    public GameObject destinationObject;

    private IDragAndDropDestination Destination
    {
        get
        {
            return destinationObject.GetComponent<IDragAndDropDestination>();
        }
    }

    private Subject<DragAndDropPhase> phasesSubject = new Subject<DragAndDropPhase>();

    public IObservable<DragAndDropPhase> Phases
    {
        get
        {
            return phasesSubject;
        }
    }    

    private GameObject draggedObject;

    private int? draggingFingerId;

    void Update()
    {
        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                draggedObject = Source.GetDraggedObject(touch);
                if (draggedObject != null)
                {
                    StartDrag(touch);
                }
            }
            else if (touch.fingerId == draggingFingerId)
            {
                if (touch.phase == TouchPhase.Canceled)
                {
                    CancelDrag();
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    if (Destination.TryAccept(touch, draggedObject))
                    {
                        AcceptDrag();
                    }
                    else
                    {
                        CancelDrag();
                    }
                }
            }
        }
    }

    private void AcceptDrag()
    {
        draggingFingerId = null;
        phasesSubject.OnNext(DragAndDropPhase.Accepted);
    }

    private void CancelDrag()
    {
        draggingFingerId = null;
        Source.ReturnObject(draggedObject);
        phasesSubject.OnNext(DragAndDropPhase.Canceled);
    }

    private void StartDrag(Touch touch)
    {
        draggingFingerId = touch.fingerId;
        Source.RemoveObject(draggedObject);
        phasesSubject.OnNext(DragAndDropPhase.Started);
    }
}
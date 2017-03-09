using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System;

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

    private Subject<Touch> touchesSubject = new Subject<Touch>();

    public IObservable<Touch> Touches
    {
        get
        {
            return touchesSubject;
        }
    }

    private GameObject draggedObject;

    public GameObject DraggedObject
    {
        get
        {
            return draggedObject;
        }
    }

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
                else if (touch.phase == TouchPhase.Moved)
                {
                    DragMoved(touch);
                }
            }
        }
    }

    private void DragMoved(Touch touch)
    {
        touchesSubject.OnNext(touch);
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
        DragMoved(touch);
    }
}
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

    private Subject<Vector3> movesSubject = new Subject<Vector3>();

    public IObservable<Vector3> Moves
    {
        get
        {
            return movesSubject;
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

    public int dragMouseButton = 0;

    private bool isMouseDragging = false;

    void Update()
    {
        if (Input.touchSupported)
        {
            DragWithTouch();
        }
        else
        {
            DragWithMouse();
        }
    }

    private void DragWithMouse()
    {
        if (Input.GetMouseButton(dragMouseButton))
        {
            if (!isMouseDragging && Input.GetMouseButtonDown(dragMouseButton))
            {
                isMouseDragging = StartDrag(Input.mousePosition);
            }

            DragMoved(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(dragMouseButton) && isMouseDragging)
        {
            EndDrag(Input.mousePosition);
            isMouseDragging = false;
        }
    }

    private void DragWithTouch()
    {
        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (draggingFingerId == null && StartDrag(touch.position))
                {
                    draggingFingerId = touch.fingerId;
                }
            }
            else if (touch.fingerId == draggingFingerId)
            {
                if (touch.phase == TouchPhase.Canceled)
                {
                    draggingFingerId = null;
                    CancelDrag();
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    draggingFingerId = null;

                    EndDrag(touch.position);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    DragMoved(touch.position);
                }
            }
        }
    }

    private void EndDrag(Vector2 position)
    {
        if (Destination.TryAccept(position, draggedObject))
        {
            AcceptDrag();
        }
        else
        {
            CancelDrag();
        }
    }

    private void DragMoved(Vector3 position)
    {
        movesSubject.OnNext(position);
    }

    private void AcceptDrag()
    {
        phasesSubject.OnNext(DragAndDropPhase.Accepted);
    }

    private void CancelDrag()
    {
        Source.ReturnObject(draggedObject);
        phasesSubject.OnNext(DragAndDropPhase.Canceled);
    }

    private bool StartDrag(Vector2 position)
    {
        draggedObject = Source.GetDraggedObject(position);
        if (draggedObject != null)
        {
            Source.RemoveObject(draggedObject);
            phasesSubject.OnNext(DragAndDropPhase.Started);
            DragMoved(position);
            return true;
        }
        return false;
    }
}
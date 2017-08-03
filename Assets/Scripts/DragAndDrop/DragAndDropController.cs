using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;
using System;

public class DragAndDropController : RxBehaviour
{
    private IDragAndDropSource[] sources;

    private IDragAndDropSource currentSource;

    private IDragAndDropDestination[] destinations;

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

    public Vector2 touchMoveOffset;

    private bool IsDragging 
    {
        get
        {
            return draggedObject != null;
        }
    }

    void Start()
    {
        sources = GameObject
            .FindGameObjectsWithTag(Tags.DragSource)
            .Select(o => o.GetComponent<IDragAndDropSource>())
            .ToArray();
        destinations = GameObject
            .FindGameObjectsWithTag(Tags.DropZone)
            .Select(o => o.GetComponent<IDragAndDropDestination>())
            .ToArray();
    }

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
            if (!IsDragging && Input.GetMouseButtonDown(dragMouseButton))
            {
                StartDrag(Input.mousePosition);
            }

            DragMoved(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(dragMouseButton) && IsDragging)
        {
            EndDrag(Input.mousePosition);
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

                    EndDrag(touch.position + touchMoveOffset);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    DragMoved(touch.position + touchMoveOffset);
                }
            }
        }
    }

    private void EndDrag(Vector2 position)
    {
        if (destinations.Any(d => d.TryAccept(position, draggedObject)))
        {
            AcceptDrag();
        }
        else
        {
            CancelDrag();
        }
        draggedObject = null;
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
        currentSource.ReturnObject(draggedObject);
        phasesSubject.OnNext(DragAndDropPhase.Canceled);
    }

    private bool StartDrag(Vector2 position)
    {
        currentSource = sources.FirstOrDefault(s => s.GetDraggedObject(position) != null);
        if (currentSource != null)
        {
            draggedObject = currentSource.GetDraggedObject(position);
            currentSource.RemoveObject(draggedObject);
            DragMoved(position);
            phasesSubject.OnNext(DragAndDropPhase.Started);
            Debug.Log("Drag started.");
            return true;
        }
        
        Debug.Log("Drag missed.");
        return false;
    }
}
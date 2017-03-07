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

    private GameObject draggedObject;

    private int? draggingFingerId;

    void Start()
    {
        // var touches = Observable.EveryUpdate()
        //     .SelectMany(_ => Input.touches)
        //     .Take(1);

        // var containerTouched = touches            
        //     .Where(t => t.phase == TouchPhase.Began)
        //     .Select(t => souceCamera.ScreenPointToRay(t.position))
        //     .SelectMany(r => Physics.RaycastAll(r, float.MaxValue, sourceLayer.value))
        //     .Where(h => h.collider == sourceContainer.gameObject.GetComponent<Collider>());

        // var sub1 = containerTouched.Subscribe(_ => {
        //     var marble = sourceContainer.content.FirstOrDefault();
        //     DestroyImmediate(marble);
        // });

        // AddSubscriptions(sub1);
    }

    void Update()
    {
        foreach(var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                draggedObject = Source.GetDraggedObject(touch);
                if (draggedObject != null)
                {
                    draggingFingerId = touch.fingerId;
                    Source.RemoveObject(draggedObject);
                }
            }
            else if (
                touch.fingerId == draggingFingerId 
                && (
                    touch.phase == TouchPhase.Canceled
                    || touch.phase == TouchPhase.Ended
                ))
            {
                draggingFingerId = null;
                if ((
                    touch.phase == TouchPhase.Ended
                    && !Destination.TryAccept(touch, draggedObject)
                    )
                    || touch.phase == TouchPhase.Canceled)
                {
                    Source.ReturnObject(draggedObject);
                }
            }
        }
    }
}
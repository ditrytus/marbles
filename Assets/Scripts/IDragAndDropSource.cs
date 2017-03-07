using System;
using UnityEngine;

public interface IDragAndDropSource
{
    GameObject GetDraggedObject(Touch touch);
    void RemoveObject(GameObject draggedObject);
    void ReturnObject(GameObject draggedObject);
}

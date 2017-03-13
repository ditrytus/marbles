using System;
using UnityEngine;

public interface IDragAndDropSource
{
    GameObject GetDraggedObject(Vector2 position);
    void RemoveObject(GameObject draggedObject);
    void ReturnObject(GameObject draggedObject);
}

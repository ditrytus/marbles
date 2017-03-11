using UnityEngine;
using System;

public interface IDragAndDropDestination
{
    bool TryAccept(Vector2 position, GameObject draggedObject);
}
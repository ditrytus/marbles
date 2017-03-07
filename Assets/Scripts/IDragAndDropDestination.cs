using UnityEngine;
using System;

public interface IDragAndDropDestination
{
    bool TryAccept(Touch touch, GameObject draggedObject);
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanInteract
{
    void InteractWithCellAt(Vector2Int movementVector);
}

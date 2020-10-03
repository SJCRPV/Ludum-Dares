using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleLink : APortalLink
{
    private enum portalNames
    {
        TOP,
        LEFT,
        RIGHT
    }

    protected override void sendToOtherPortal(ABoardPiece boardPiece, int siblingIndex)
    {
        bool isMovingLeft = boardPiece.MovementDirection == MovementDirection.LEFT;
        Vector3 basePosition;
        Vector3Int newCoords;
        switch (siblingIndex)
        {
            case (int)portalNames.TOP:
                basePosition = isMovingLeft ? Portals[(int)portalNames.RIGHT].transform.position : Portals[(int)portalNames.LEFT].transform.position;
                break;
            case (int)portalNames.LEFT:
            case (int)portalNames.RIGHT:
                basePosition = Portals[(int)portalNames.TOP].transform.position;                
                break;
            default:
                Debug.LogError($"{name} has an unknown sibling index. What's at {siblingIndex}?");
                return;
        }
        newCoords = _grid.WorldToCell(basePosition);
        newCoords.x += isMovingLeft ? -1 : 1;

        boardPiece.transform.position = _grid.GetCellCenterWorld(newCoords);
    }

    private new void OnValidate()
    {
        base.OnValidate();
    }

    // Start is called before the first frame update
    private new void Start() => base.Start();
}

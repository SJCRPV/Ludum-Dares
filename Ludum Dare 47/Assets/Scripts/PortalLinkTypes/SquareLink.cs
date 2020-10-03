using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLink : APortalLink
{
    private enum portalNames
    {
        TOP_LEFT,
        TOP_RIGHT,
        BOT_LEFT,
        BOT_RIGHT
    }

    protected override void sendToOtherPortal(ABoardPiece boardPiece, int siblingIndex)
    {
        bool isMovingRight = boardPiece.MovementDirection == MovementDirection.RIGHT;
        Vector3 basePosition;
        Vector3Int newCoords;
        switch (siblingIndex)
        {
            case (int)portalNames.TOP_LEFT:
                basePosition = Portals[(int)portalNames.BOT_LEFT].transform.position;
                break;
            case (int)portalNames.TOP_RIGHT:
                basePosition = Portals[(int)portalNames.BOT_RIGHT].transform.position;
                break;
            case (int)portalNames.BOT_LEFT:
                basePosition = Portals[(int)portalNames.TOP_LEFT].transform.position;
                break;
            case (int)portalNames.BOT_RIGHT:
                basePosition = Portals[(int)portalNames.TOP_RIGHT].transform.position;
                break;
            default:
                Debug.LogError($"{name} has an unknown sibling index. What's at {siblingIndex}?");
                return;
        }
        newCoords = _grid.WorldToCell(basePosition);
        newCoords.x += isMovingRight ? 1 : -1;

        boardPiece.transform.position = _grid.GetCellCenterWorld(newCoords);
    }

    private new void OnValidate()
    {
        base.OnValidate();
    }

    // Start is called before the first frame update
    private new void Start() => base.Start();
}

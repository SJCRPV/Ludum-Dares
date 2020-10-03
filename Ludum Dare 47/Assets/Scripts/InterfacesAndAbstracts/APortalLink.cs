using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class APortalLink : MonoBehaviour
{
    protected Grid _grid;
    public List<Portal> Portals { get; protected set; }

    /// <summary>
    /// This base function is assuming only 2 portals exist.
    /// </summary>
    /// <param name="boardPiece">The piece to be teleported</param>
    /// <param name="siblingIndex">The index of the portal in the link. Used to determine which portal in the sequence this is</param>
    protected virtual void sendToOtherPortal(ABoardPiece boardPiece, int siblingIndex)
    {
        bool isFirstPortal = siblingIndex == 0;
        Vector3 basePosition = isFirstPortal ? Portals[1].transform.position : Portals[0].transform.position;

        Vector3Int newCoords = _grid.WorldToCell(basePosition);
        newCoords.x = boardPiece.MovementDirection == MovementDirection.LEFT ? newCoords.x - 1 : newCoords.x + 1;

        boardPiece.transform.position = _grid.GetCellCenterWorld(newCoords);
    }

    protected void OnValidate()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            _grid = FindObjectOfType<Grid>();
            Portals = new List<Portal>(transform.GetComponentsInChildren<Portal>());
            transform.position = _grid.GetCellCenterWorld(_grid.WorldToCell(transform.position));
        }
    }

    // Start is called before the first frame update
    protected void Start()
    {        
        _grid = DependencyContainer.Instance.Get<Grid>();
        Portals = GetComponentsInChildren<Portal>().ToList();

        foreach (Portal portal in Portals)
        {
            portal.OnPortalEnter += sendToOtherPortal;
        }
    }
}

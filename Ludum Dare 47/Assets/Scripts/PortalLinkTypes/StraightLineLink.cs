using System.Collections.Generic;
using UnityEngine;

public class StraightLineLink : APortalLink
{
    [SerializeField]
    private int distanceBetweenPortals = 20;

    private void separatePortals()
    {
        Vector3Int basePos = _grid.WorldToCell(transform.position);

        Portals[0].transform.position = _grid.GetCellCenterWorld(new Vector3Int(basePos.x - Mathf.CeilToInt(distanceBetweenPortals / 2), basePos.y, basePos.z));
        Portals[1].transform.position = _grid.GetCellCenterWorld(new Vector3Int(basePos.x + Mathf.FloorToInt(distanceBetweenPortals / 2) - 1, basePos.y, basePos.z));
    }

    private new void OnValidate()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            base.OnValidate();
            separatePortals();
        }
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }
}

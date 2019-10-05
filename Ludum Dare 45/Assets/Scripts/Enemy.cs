using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private List<Vector3Int> weakPoints;
    [SerializeField]
    private GameObject weakPointPrefab;
    [SerializeField]
    private int cellWidth;
    public int CellWidth { get { return cellWidth; } set { cellWidth = value; } }
    [SerializeField]
    private int cellHeight;
    public int CellHeight { get { return cellHeight; } set { cellHeight = value; } }
    private Grid grid;
    

    private SpriteRenderer isThereBlockAt(Vector3 potentialPos)
    {
        Ray2D ray = new Ray2D(potentialPos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero);

        return hit.collider == null ? null : hit.collider.GetComponent<SpriteRenderer>();
    }

    private void placeWeakPoints()
    {
        Vector3Int currentGridPos = grid.LocalToCell(transform.localPosition);
        foreach (Vector3Int weakPoint in weakPoints)
        {
            Vector3 weakPointSpot = grid.CellToLocal(currentGridPos + weakPoint);
            SpriteRenderer potentialBlock = isThereBlockAt(weakPointSpot);
            if (potentialBlock != null)
            {
                Destroy(potentialBlock.gameObject);
            }
            Instantiate(weakPointPrefab, transform, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

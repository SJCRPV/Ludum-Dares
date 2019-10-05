using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAssembler : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private List<Color> possibleColours;
    [SerializeField]
    private List<GameObject> possibleEnemies;
    [SerializeField]
    private int blocksWide;
    [SerializeField]
    private int blocksHigh;
    [SerializeField]
    private int numberOfEnemies;
    private Transform gridObj;
    private Grid grid;

    private void randomiseBlockColours()
    {
        foreach (SpriteRenderer spriteRenderer in gridObj.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.color = possibleColours[Mathf.RoundToInt(Random.Range(0, possibleColours.Count))];
        }
    }

    private SpriteRenderer isThereBlockAt(Vector3 potentialPos)
    {
        Ray2D ray = new Ray2D(potentialPos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero);

        return hit.collider == null ? null : hit.collider.GetComponent<SpriteRenderer>();
    }

    private void carveEnemyArea(Vector3Int enemyPos, int cellWidth, int cellHeight)
    {
        for(int i = -cellWidth / 2; i < cellWidth / 2; i++)
        {
            for(int j = -cellHeight / 2; i < cellHeight / 2; j++)
            {
                //Destroy(isThereBlockAt())
            }
        }
    }

    private Vector3Int getRandomEnemyPos(int cellWidth, int cellHeight)
    {
        int minX = -blocksWide / 2 + cellWidth / 2;
        int maxX = blocksWide / 2 - cellWidth / 2;
        int minY = -blocksHigh / 2 + cellHeight / 2;
        int maxY = blocksHigh / 2 - cellHeight / 2;

        //int randXCoord = Mathf.RoundToInt(Random.Range())
        return Vector3Int.zero;
    }

    private void placeEnemies()
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemyPrefab = possibleEnemies[Mathf.RoundToInt(Random.Range(0, possibleEnemies.Count))];
            Enemy enemyScript = enemyPrefab.GetComponent<Enemy>();
            
            Vector3Int enemyPos = getRandomEnemyPos(enemyScript.CellWidth, enemyScript.CellHeight);
            carveEnemyArea(enemyPos, enemyScript.CellWidth, enemyScript.CellHeight);

            GameObject enemy = Instantiate(enemyPrefab, gridObj, false);
            //enemy
        }
    }

    private void carveCharacterAreas()
    {
        int numOfCharacters = CharacterManager.instance == null ? 0 : CharacterManager.instance.charactersList.Count;
        int xCoord;
        int yCoord;
        Vector3 charPosition;
        switch (numOfCharacters)
        {
            case 0:
                break;
            case 1:
                xCoord = Mathf.RoundToInt(Random.Range(-1, 1));
                yCoord = Mathf.RoundToInt(Random.Range(-1, 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);
                break;

            case 2:
                xCoord = Mathf.RoundToInt(Random.Range(-blocksWide + 2, -blocksWide + 4));
                yCoord = Mathf.RoundToInt(Random.Range(-1, 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);

                xCoord = Mathf.RoundToInt(Random.Range(blocksWide - 2, blocksWide - 4));
                yCoord = Mathf.RoundToInt(Random.Range(-1, 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);
                break;

            case 3:
                xCoord = Mathf.RoundToInt(Random.Range(-blocksWide / 2 - 1, -blocksWide / 2 + 1));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh / 4 - 1, blocksHigh / 4 + 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);

                xCoord = Mathf.RoundToInt(Random.Range(blocksWide / 2 - 1, blocksWide / 2 - 1));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh / 4 - 1, blocksHigh / 4 + 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);

                xCoord = Mathf.RoundToInt(Random.Range(-1, 1));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh / 2 - 1, blocksHigh / 2 + 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);
                break;

            case 4:
                xCoord = Mathf.RoundToInt(Random.Range(-blocksWide + 2, -blocksWide + 4));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh - 2, blocksHigh - 4));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);

                xCoord = Mathf.RoundToInt(Random.Range(-blocksWide + 2, -blocksWide + 4));
                yCoord = Mathf.RoundToInt(Random.Range(-blocksHigh + 2, -blocksHigh + 4));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);

                xCoord = Mathf.RoundToInt(Random.Range(blocksWide - 2, blocksWide - 4));
                yCoord = Mathf.RoundToInt(Random.Range(-blocksHigh + 2, -blocksHigh + 4));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);

                xCoord = Mathf.RoundToInt(Random.Range(blocksWide - 2, blocksWide - 4));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh - 2, blocksHigh - 4));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.CellToLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);
                break;
            default:
                //Error
                Debug.LogError("There's apparently " + numOfCharacters + " characters at the moment.");
                break;
        }
    }

    private void fillLevel()
    {
        for(int i = -blocksWide / 2; i < blocksWide / 2; i++)
        {
            for (int j = -blocksHigh / 2; j < blocksHigh / 2; j++)
            {
                GameObject block = Instantiate(blockPrefab, gridObj, false);
                block.transform.localPosition = grid.GetCellCenterLocal(new Vector3Int(i, j, 0));
                block.name = string.Format("{0}, {1}", i, j);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gridObj = GameObject.Find("Grid").transform;
        grid = gridObj.GetComponent<Grid>();
        fillLevel();
        carveCharacterAreas();
        placeEnemies();
        randomiseBlockColours();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

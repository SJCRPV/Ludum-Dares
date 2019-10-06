using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAssembler : MonoBehaviour
{
    public static LevelAssembler instance;

    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private List<Color> possibleColours;
    public List<Color> PossibleColours { get { return possibleColours; } set { possibleColours = value; } }
    private List<GameObject> possibleEnemies;
    private int blocksWide;
    private int blocksHigh;
    private int numberOfEnemies;
    private Transform gridObj;
    private Grid grid;

    private void randomiseBlockColours()
    {
        if(LevelManager.instance.levelCounter > 0)
        {
            foreach (SpriteRenderer spriteRenderer in gridObj.GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.color = possibleColours[Mathf.RoundToInt(Random.Range(0, possibleColours.Count))];
            }
        }
    }

    private SpriteRenderer isThereBlockAt(Vector3 potentialPos)
    {
        Ray2D ray = new Ray2D(potentialPos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.zero);

        return hit.collider?.GetComponent<SpriteRenderer>();
    }

    private void carveEnemyArea(Vector3Int enemyPos, int cellWidth, int cellHeight)
    {
        for(int i = -cellWidth / 2 - 1; i < cellWidth / 2; i++)
        {
            for(int j = -cellHeight / 2 - 1; j < cellHeight / 2; j++)
            {
                Vector3Int posOffset = new Vector3Int(i, j, 0);
                Vector3Int adaptedCellPos = enemyPos + posOffset;
                GameObject block = gridObj.Find(adaptedCellPos.x + ", " + adaptedCellPos.y).gameObject;
                if(block != null)
                {
                    Destroy(block.gameObject);
                }
            }
        }
    }

    private Vector3Int getRandomEnemyPos(int cellWidth, int cellHeight)
    {
        int minX = -blocksWide / 2 + cellWidth / 2;
        int maxX = blocksWide / 2 - cellWidth / 2;
        int minY = -blocksHigh / 2 + cellHeight / 2;
        int maxY = blocksHigh / 2 - cellHeight / 2;

        bool isTooCloseToCharacter;
        Vector3Int enemyPosition;
        do
        {
            isTooCloseToCharacter = false;
            int randXCoord = Mathf.RoundToInt(Random.Range(minX + 1, maxX));
            int randYCoord = Mathf.RoundToInt(Random.Range(minY + 1, maxY));
            enemyPosition = new Vector3Int(randXCoord, randYCoord, 0);

            if(CharacterManager.instance != null)
            {
                foreach (GameObject character in CharacterManager.instance.charactersList)
                {
                    Vector3Int charPosition = grid.LocalToCell(character.transform.localPosition);
                    if(Vector3Int.Distance(enemyPosition, charPosition) < 8)
                    {
                        isTooCloseToCharacter = true;
                    }
                }
            }
        } while (isTooCloseToCharacter);
        
        return enemyPosition;
    }

    private void placeEnemies()
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemyPrefab = possibleEnemies[Mathf.RoundToInt(Random.Range(0, possibleEnemies.Count))];
            Enemy enemyScript = enemyPrefab.GetComponent<Enemy>();
            
            Vector3Int enemyCellPos = getRandomEnemyPos(enemyScript.CellsWide, enemyScript.CellsTall);
            //Vector3 enemyLocalPos = grid.GetCellCenterLocal(enemyCellPos) - (new Vector3(grid.cellSize.x * 2, grid.cellSize.y, 0) / 2) - (new Vector3(grid.cellGap.x * 1.5f, grid.cellGap.y, 0));
            Vector3 enemyLocalPos = grid.GetCellCenterLocal(enemyCellPos) - enemyScript.PositionCorrection;
            carveEnemyArea(enemyCellPos, enemyScript.CellsWide, enemyScript.CellsTall);

            GameObject enemy = Instantiate(enemyPrefab, gridObj, false);
            enemy.transform.localPosition = enemyLocalPos;
            LevelManager.instance.enemiesStillInTheLevel.Add(enemy.GetComponent<Enemy>());
        }
    }

    private void carveCharacterAreas()
    {
        int numOfCharacters = CharacterManager.instance == null ? 0 : CharacterManager.instance.NumOfCharacters;
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
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition, controlThisCharacter: true);
                break;

            case 2:
                xCoord = Mathf.RoundToInt(Random.Range(-blocksWide + 2, -blocksWide + 4));
                yCoord = Mathf.RoundToInt(Random.Range(-1, 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition, controlThisCharacter: true);

                xCoord = Mathf.RoundToInt(Random.Range(blocksWide - 2, blocksWide - 4));
                yCoord = Mathf.RoundToInt(Random.Range(-1, 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);
                break;

            case 3:
                xCoord = Mathf.RoundToInt(Random.Range(-blocksWide / 2 - 1, -blocksWide / 2 + 1));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh / 4 - 1, blocksHigh / 4 + 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition, controlThisCharacter: true);

                xCoord = Mathf.RoundToInt(Random.Range(blocksWide / 2 - 1, blocksWide / 2 - 1));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh / 4 - 1, blocksHigh / 4 + 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);

                xCoord = Mathf.RoundToInt(Random.Range(-1, 1));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh / 2 - 1, blocksHigh / 2 + 1));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);
                break;

            case 4:
                xCoord = Mathf.RoundToInt(Random.Range(-blocksWide + 2, -blocksWide + 4));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh - 2, blocksHigh - 4));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition, controlThisCharacter: true);

                xCoord = Mathf.RoundToInt(Random.Range(-blocksWide + 2, -blocksWide + 4));
                yCoord = Mathf.RoundToInt(Random.Range(-blocksHigh + 2, -blocksHigh + 4));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);

                xCoord = Mathf.RoundToInt(Random.Range(blocksWide - 2, blocksWide - 4));
                yCoord = Mathf.RoundToInt(Random.Range(-blocksHigh + 2, -blocksHigh + 4));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
                CharacterManager.instance.SpawnCharacterAt(charPosition);

                xCoord = Mathf.RoundToInt(Random.Range(blocksWide - 2, blocksWide - 4));
                yCoord = Mathf.RoundToInt(Random.Range(blocksHigh - 2, blocksHigh - 4));
                Destroy(gridObj.Find(xCoord + ", " + yCoord).gameObject);
                charPosition = grid.GetCellCenterLocal(new Vector3Int(xCoord, yCoord, 0));
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

    public void GenerateLevel()
    {
        fillLevel();
        carveCharacterAreas();
        placeEnemies();
        randomiseBlockColours();
    }

    public void DefineGenerationParameters(int level)
    {
        LevelManager levelManager = LevelManager.instance;
        blocksWide = levelManager.dimensionsPerLevel[level].x;
        blocksHigh = levelManager.dimensionsPerLevel[level].y;
        possibleEnemies = levelManager.possibleEnemiesPerLevel[level];
        numberOfEnemies = levelManager.numOfEnemiesPerLevel[level];
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        gridObj = GameObject.Find("Grid").transform;
        grid = gridObj.GetComponent<Grid>();
        DefineGenerationParameters(level: LevelManager.instance.levelCounter);
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

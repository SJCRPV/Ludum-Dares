using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int levelCounter;
    public List<Enemy> enemiesStillInTheLevel;
    public List<Vector2Int> dimensionsPerLevel;
    public List<List<GameObject>> possibleEnemiesPerLevel;
    [SerializeField]
    private List<GameObject> possibleEnemiesLevel0;
    [SerializeField]
    private List<GameObject> possibleEnemiesLevel1;
    [SerializeField]
    private List<GameObject> possibleEnemiesLevel2;
    public List<int> numOfEnemiesPerLevel;
    public GameObject stairsPrefab;
    private Transform grid;

    public void ClearLevel()
    {
        foreach (Transform block in grid)
        {
            Destroy(block.gameObject);
        }

        foreach (Enemy enemy in enemiesStillInTheLevel)
        {
            Destroy(enemy.gameObject);
        }
    }

    public void AnnounceStep()
    {
        foreach (Enemy enemy in enemiesStillInTheLevel.Where(enemy => enemy.IsActivated))
        {
            enemy.StepCounter++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        enemiesStillInTheLevel = new List<Enemy>();
        possibleEnemiesPerLevel = new List<List<GameObject>>() { possibleEnemiesLevel0, possibleEnemiesLevel1, possibleEnemiesLevel2 };
        grid = GameObject.Find("Grid").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

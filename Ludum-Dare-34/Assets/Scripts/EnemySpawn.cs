using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject basicDudePrefab;
    public GameObject rangeDudePrefab;
    public GameObject comboDudePrefab;

    private GameObject basicDudeInstance;
    private GameObject rangeDudeInstance;
    private GameObject comboDudeInstance;

    float i = 3f;
    //Figure out how you'll do the levels
    void SpawnEnemies()
    {
        basicDudeInstance = (GameObject)Instantiate(basicDudePrefab, transform.position, Quaternion.identity);
        rangeDudeInstance = (GameObject)Instantiate(rangeDudePrefab, transform.position, Quaternion.identity);
        comboDudeInstance = (GameObject)Instantiate(comboDudePrefab, transform.position, Quaternion.identity);
    }

	// Use this for initialization
	void Start () {
        SpawnEnemies();
	}

    void Update()
    {
        i -= Time.deltaTime;
        if(i <= 0)
        {
            SpawnEnemies();
            i = 3f;
        }
    }
}

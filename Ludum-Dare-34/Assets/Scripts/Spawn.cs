using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject objectToSpawn;

    private GameObject objectInstance;

    private void assignChild()
    {
        if (objectInstance != null)
        {
            objectInstance.transform.parent = this.transform;
        }
    }


    void SpawnPlayer()
    {
        //Spawns in the wrong X Coordinates.
        objectInstance = (GameObject)Instantiate(objectToSpawn);
        objectInstance.name = "MainChar";
        assignChild();
        objectInstance.transform.position = new Vector2(-8.5f, -2.4f);
    }

    void Start()
    {
        SpawnPlayer();
    }
}

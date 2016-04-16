using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateCitizens : MonoBehaviour {

    public int numCitizensToSpawn;
    public GameObject citizenPrefab;
    public Material[] materialList = new Material[8];

    private List<GameObject> citizenPool;
    private Renderer citizenRenderer;
    private int target;

    public int getCitizenPoolLength()
    {
        return citizenPool.Count;
    }

    public GameObject getCitizenAt(int index)
    {
        return citizenPool[index];
    }

    void selectTarget()
    {
        target = Random.Range(0, citizenPool.Count);
        Behaviour halo = (Behaviour)citizenPool[target].GetComponent("Halo");
        halo.enabled = true;
        citizenPool[target].name = "Target";
        Debug.Log("Target is the citizen at " + target);
    }

    void assignMaterial()
    {
        citizenRenderer.sharedMaterial = materialList[Random.Range(0, 7)];
        citizenPrefab.GetComponent<Renderer>().sharedMaterial = citizenRenderer.sharedMaterial;
    }

    void createCitizens()
    {
        for (int i = 0; i < numCitizensToSpawn; i++)
        {
            citizenRenderer = citizenPrefab.GetComponent<Renderer>();
            assignMaterial();
            citizenPool.Add((GameObject)citizenPrefab);
            citizenPool[i] = Instantiate(citizenPool[i]);
            citizenPool[i].name = "Citizen " + (i + 1);
            citizenPool[i].transform.position = new Vector3(Random.Range(10, 490), 1, Random.Range(10, 490));
        }
    }

	// Use this for initialization
	void Start () {
        citizenPool = new List<GameObject>();
        createCitizens();
        selectTarget();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class GenerateCitizens : MonoBehaviour {

    public int numCitizensToSpawn;
    public GameObject citizenPrefab;
    public Material[] materialList = new Material[8];

    private GameObject citizenInstance;
    private GameObject[] citizenPool;
    private Renderer citizenRenderer;
    private int target;

    public int getCitizenPoolLength()
    {
        return citizenPool.Length;
    }

    public GameObject getCitizenAt(int index)
    {
        return citizenPool[index];
    }

    void selectTarget()
    {
        target = Random.Range(0, citizenPool.Length);
        Behaviour halo = (Behaviour)citizenPool[target].GetComponent("Halo");
        halo.enabled = true;
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
            citizenPool[i] = Instantiate((GameObject)citizenPrefab);
            citizenPool[i].transform.position = new Vector3(Random.Range(-90, 90), 0, Random.Range(-90, 90));
        }
    }

	// Use this for initialization
	void Start () {
        citizenPool = new GameObject[numCitizensToSpawn];
        createCitizens();
        selectTarget();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

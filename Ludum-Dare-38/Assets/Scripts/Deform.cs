using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deform : MonoBehaviour {

    protected Terrain terrain;
    protected TerrainData terrData;
    protected int terrWidth;
    protected int terrHeight;

    protected Vector3 convertToTerrainCoords(Vector3 worldCoor)
    {
        Vector3 returnVector = new Vector3();
        Vector3 terrainPos = terrain.transform.position;

        returnVector.x = ((worldCoor.x - terrainPos.x) / terrData.size.x) * terrData.alphamapWidth;
        returnVector.z = ((worldCoor.y - terrainPos.z) / terrData.size.z) * terrData.alphamapHeight;

        return returnVector;
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

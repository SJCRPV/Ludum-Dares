using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deform : MonoBehaviour {

    protected Terrain terrainToDeform;
    protected TerrainData terrainData;
    protected int terrWidth;
    protected int terrHeight;

    private Vector3 convertToTerrainCoords(Vector3 worldCoor)
    {
        Vector3 returnVector = new Vector3();
        Vector3 terrainPos = terrainToDeform.transform.position;

        returnVector.x = ((worldCoor.x - terrainPos.x) / terrainData.size.x) * terrainData.alphamapWidth;
        returnVector.z = ((worldCoor.y - terrainPos.z) / terrainData.size.z) * terrainData.alphamapHeight;

        return returnVector;
    }

    // Use this for initialization
    void Start () {
        terrainToDeform = Terrain.activeTerrain;
        terrainData = terrainToDeform.terrainData;
        terrWidth = terrainData.heightmapWidth;
        terrHeight = terrainData.heightmapHeight;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

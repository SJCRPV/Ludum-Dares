using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDeform : MonoBehaviour {

    Terrain terrainToDeform;
    TerrainData terrainData;
    float[,] fullHeightMap;
    float[,] heightMapToDeform;

    private int terrWidth;
    private int terrHeight;

    //Returns height at that point.
    //terrainToDeform.SampleHeight(point);

    /*
     * private Vector3 ConvertWordCor2TerrCor(Vector3 wordCor)
{
    Vector3 vecRet = new Vector3();
    Terrain ter = Terrain.activeTerrain;
    Vector3 terPosition =  ter.transform.position;
    vecRet.x = ((wordCor.x - terPosition.x) / ter.terrainData.size.x) * ter.terrainData.alphamapWidth;
    vecRet.z = ((wordCor.y - terPosition.z) / ter.terrainData.size.z) * ter.terrainData.alphamapHeight;
    return vecRet;
}
     * */

    private Vector3 convertToTerrainCoords(Vector3 worldCoor)
    {
        Vector3 returnVector = new Vector3();
        Vector3 terrainPos = terrainToDeform.transform.position;

        returnVector.x = ((worldCoor.x - terrainPos.x) / terrainData.size.x) * terrainData.alphamapWidth;
        returnVector.z = ((worldCoor.y - terrainPos.z) / terrainData.size.z) * terrainData.alphamapHeight;

        return returnVector;
    }

    public void deformTerrain(Vector3 point, float force, int forceRadius)
    {
        //point = convertToTerrainCoords(point);
        float[,] temp = terrainData.GetHeights((int)(point.x - forceRadius/2), (int)(point.z - forceRadius/2), forceRadius, forceRadius);
        for(int i = 0; i < temp.GetLength(0); i++)
        {
            for(int j = 0; j < temp.GetLength(1); j++)
            {
                Debug.Log(temp[i, j]);
                temp[i, j] += force * Time.deltaTime;
            }
        }

        terrainData.SetHeights((int)(point.x - forceRadius/2), (int)(point.z - forceRadius/2), temp);
    }

    // Use this for initialization
    void Start() {
        terrainToDeform = Terrain.activeTerrain;
        terrainData = terrainToDeform.terrainData;
        terrWidth = terrainData.heightmapWidth;
        terrHeight = terrainData.heightmapHeight;
        fullHeightMap = terrainData.GetHeights(0, 0, terrWidth, terrHeight);
        heightMapToDeform = new float[fullHeightMap.GetLength(0), fullHeightMap.GetLength(1)];
	}
	
	// Update is called once per frame
	void Update () {

	}
}

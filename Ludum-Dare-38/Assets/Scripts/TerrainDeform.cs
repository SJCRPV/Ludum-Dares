using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDeform : Deform {

    float[,] fullHeightMap;
    float[,] heightMapToDeform;

    //Returns height at that point.
    //terrainToDeform.SampleHeight(point);

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
        
        fullHeightMap = terrainData.GetHeights(0, 0, terrWidth, terrHeight);
        heightMapToDeform = new float[fullHeightMap.GetLength(0), fullHeightMap.GetLength(1)];
	}
	
	// Update is called once per frame
	void Update () {

	}
}

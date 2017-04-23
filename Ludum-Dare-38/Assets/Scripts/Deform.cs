using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deform : MonoBehaviour {

    protected Terrain terrain;
    protected TerrainData terrData;
    protected int terrWidth;
    protected int terrHeight;
    protected Vector3 terrainSize;
    protected int heightMapWidth;
    protected int heightMapHeight;
    protected float[,] heightMapData;
    protected float[,,] alphaMapData;

    public Vector3 getHeightMapPosition(Vector3 point)
    {
        Vector3 heightMapPos = new Vector3();

        //Find position of hit in heightmap
        heightMapPos.x = (point.x / terrainSize.x) * heightMapWidth;
        heightMapPos.z = (point.z / terrainSize.z) * heightMapHeight;

        heightMapPos.x = Mathf.RoundToInt(heightMapPos.x);
        heightMapPos.z = Mathf.RoundToInt(heightMapPos.z);

        //Clamp to heightMap dimensions to avoid errors
        heightMapPos.x = Mathf.Clamp(heightMapPos.x, 0, heightMapWidth - 1);
        heightMapPos.z = Mathf.Clamp(heightMapPos.z, 0, heightMapHeight - 1);

        return heightMapPos;
    }

    protected void getTerrainData()
    {
        terrain = Terrain.activeTerrain;
        terrData = terrain.terrainData;
        terrainSize = terrData.size;

        heightMapWidth = terrData.heightmapWidth;
        heightMapHeight = terrData.heightmapHeight;

        heightMapData = terrData.GetHeights(0, 0, heightMapWidth, heightMapHeight);
        alphaMapData = terrData.GetAlphamaps(0, 0, terrData.alphamapWidth, terrData.alphamapHeight);
    }
}

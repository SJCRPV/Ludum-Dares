using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDeform : Deform
{

    private Vector3 terrainSize;
    private int heightMapWidth;
    private int heightMapHeight;
    private float[,] heightMapData;

    private void resetHeights()
    {
        for (int z = 0; z < heightMapHeight; z++)
        {
            for (int x = 0; x < heightMapWidth; x++)
            {
                heightMapData[z, x] = 0;
            }
        }

        terrData.SetHeights(0, 0, heightMapData);
    }

    public void deformTerrain(Vector3 point, float force, int brushRadius)
    {
        int x;
        int z;
        int heightX;
        int heightZ;
        float heightY;
        Vector2 calc;

        for (z = -brushRadius; z <= brushRadius; z++)
        {
            for (x = -brushRadius; x <= brushRadius; x++)
            {
                //https://docs.unity3d.com/ScriptReference/Vector3-magnitude.html
                calc = new Vector2(x, z);

                if (calc.magnitude <= brushRadius)
                {
                    heightX = (int)point.x + x;
                    heightZ = (int)point.z + z;

                    if ((heightX >= 0 && heightX < heightMapWidth) && (heightZ >= 0 && heightZ < heightMapHeight))
                    {
                        heightY = heightMapData[heightZ, heightX];

                        heightY += force;

                        heightMapData[heightZ, heightX] = heightY;
                    }
                }
            }
        }

        terrData.SetHeights(0, 0, heightMapData);
    }

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

    private void getTerrainData()
    {
        terrain = Terrain.activeTerrain;
        terrData = terrain.terrainData;
        terrainSize = terrData.size;

        heightMapWidth = terrData.heightmapWidth;
        heightMapHeight = terrData.heightmapHeight;

        heightMapData = terrData.GetHeights(0, 0, heightMapWidth, heightMapHeight);
    }

    private void Start()
    {
        getTerrainData();

        resetHeights();
    }
}
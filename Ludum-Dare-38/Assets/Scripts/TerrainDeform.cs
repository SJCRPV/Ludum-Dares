using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDeform : Deform
{
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
        int heightX;
        int heightZ;
        float heightY;
        Vector2 calc;

        for (int z = -brushRadius; z <= brushRadius; z++)
        {
            for (int x = -brushRadius; x <= brushRadius; x++)
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

    private void Start()
    {
        getTerrainData();

        //resetHeights();
    }
}
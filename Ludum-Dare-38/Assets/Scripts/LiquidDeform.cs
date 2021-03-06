﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDeform : Deform
{
    [SerializeField]
    private Texture waterTexture;

    private const int DESERT = 0;
    private const int WATER = 1;

    public void deformLiquids(Vector3 point, int brushRadius, bool rightClick)
    {
        int heightX;
        int heightZ;
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
                        if (!rightClick)
                        {
                            //alphaMapData[heightZ, heightX, TextureToChange] = alphaLevel (between 0f-1f);
                            alphaMapData[heightZ, heightX, WATER] = 1;
                            alphaMapData[heightZ, heightX, DESERT] = 0;
                        }
                        else
                        {
                            alphaMapData[heightZ, heightX, DESERT] = 1;
                            alphaMapData[heightZ, heightX, WATER] = 0;
                        }
                    }
                }
            }
        }
        terrData.SetAlphamaps(0, 0, alphaMapData);
    }

    // Use this for initialization
    void Start()
    {
        getTerrainData();
    }
}

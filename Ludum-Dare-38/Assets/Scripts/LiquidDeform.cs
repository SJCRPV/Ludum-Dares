using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDeform : Deform
{

    [SerializeField]
    private Texture waterTexture;

    private const int DESERT = 0;
    private const int WATER = 1;

    private float[] getTextureMix(Vector3 worldPos)
    {
        Vector3 temp = getHeightMapPosition(worldPos);
        
        //Avoids getting "Out of terrain" errors
        if (temp.x > 511 || temp.x < 0 || temp.z > 511 || temp.z < 0)
        {
            temp.x = 0;
            temp.z = 0;
        }

        //Returns a 1x1xN array where N = number of Textures
        float[,,] splatMapData = terrData.GetAlphamaps((int)temp.x, (int)temp.z, 1, 1);

        //Array that will hold the texture numbers
        float[] cellMix = new float[splatMapData.GetUpperBound(2) + 1];

        for (int i = 0; i < cellMix.Length; i++)
        {
            cellMix[i] = splatMapData[0, 0, i];
        }
        return cellMix;
    }

    private int getMainTexture(Vector3 worldPos)
    {
        float[] mix = getTextureMix(worldPos);

        float maxMix = 0;
        int maxIndex = 0;

        for (int i = 0; i < mix.Length; i++)
        {
            if (mix[i] > maxMix)
            {
                maxIndex = i;
                maxMix = mix[i];
            }
        }
        return maxIndex;
    }

    public void deformLiquids(Vector3 point, float force, int brushRadius, bool rightClick)
    {
        //int mainTexture = getMainTexture(point);
        int heightX;
        int heightZ;
        Vector2 calc;
        int water = waterTexture.GetInstanceID();

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

    // Update is called once per frame
    void Update()
    {

    }
}

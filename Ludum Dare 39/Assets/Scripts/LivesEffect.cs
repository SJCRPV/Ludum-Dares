using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesEffect : Effect {

    private static int livesValue;
    private int min;
    private int max;
    private int random;

    public int getRandomNum()
    {
        return Mathf.RoundToInt(UnityEngine.Random.Range(min, max));
    }

    public int Max
    {
        get
        {
            return max;
        }
    }

    public int Min
    {
        get
        {
            return min;
        }
    }

    public override int getVarValue()
    {
        return livesValue;
    }

    public override void changeVarValue(int difference)
    {
        livesValue += difference;
    }

    public LivesEffect(int nMin, int nMax)
    {
        min = nMin;
        max = nMax;
    }
}

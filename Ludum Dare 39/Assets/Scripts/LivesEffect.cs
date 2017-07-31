using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesEffect : Effect {

    private static int livesRemaining = 100000;
    private static int livesLost = 0;
    private int min;
    private int max;
    //private int random;

    public static int staticGetLivesRemaining()
    {
        return livesRemaining;
    }
    public static int staticGetLivesLost()
    {
        return livesLost;
    }

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
        return livesRemaining;
    }

    public override void changeVarValue(int difference)
    {
        livesRemaining -= difference;
        livesLost += difference;
    }

    public LivesEffect(int nMin, int nMax)
    {
        min = nMin;
        max = nMax;
    }

    public static new string ToString
    {
        get
        {
            return "LivesEffect";
        }
    }
}

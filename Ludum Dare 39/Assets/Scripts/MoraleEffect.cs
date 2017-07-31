using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleEffect : Effect
{
    //Swings between 0-10
    private static int moraleValue = 5;

    public static int staticGetMoraleValue()
    {
        return moraleValue;
    }

    public override void changeVarValue(int difference)
    {
        moraleValue += difference;
    }

    public override int getVarValue()
    {
        return moraleValue;
    }

    public static new string ToString
    {
        get
        {
            return "MoraleEffect";
        }
    }
}

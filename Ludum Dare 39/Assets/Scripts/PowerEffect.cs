using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEffect : Effect {

    private static int powerValue = 100;

    public static void staticChangeVarValue(int value)
    {
        powerValue += value;
    }
    public static int staticGetVarValue()
    {
        return powerValue;
    }

    public override void changeVarValue(int difference)
    {
        powerValue += difference;
    }

    public override int getVarValue()
    {
        return powerValue;
    }

    public static new string ToString
    {
        get
        {
            return "PowerEffect";
        }
    }
}

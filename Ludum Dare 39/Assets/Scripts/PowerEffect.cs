using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEffect : Effect {

    private static int powerValue;

    public override void changeVarValue(int difference)
    {
        powerValue += difference;
    }

    public override int getVarValue()
    {
        return powerValue;
    }
}

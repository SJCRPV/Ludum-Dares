using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleEffect : Effect
{
    private static int moraleValue;

    public override void changeVarValue(int difference)
    {
        moraleValue += difference;
    }

    public override int getVarValue()
    {
        return moraleValue;
    }
}

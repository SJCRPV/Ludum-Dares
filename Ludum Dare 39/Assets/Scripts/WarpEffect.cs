using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpEffect : Effect {

    private static int jumpsMade = 0;
    private static int jumpsLeft = 10;

    public static int JumpsMade
    {
        get
        {
            return jumpsMade;
        }
    }

    public static int JumpsLeft
    {
        get
        {
            return jumpsLeft;
        }
    }

    public static void changeValuesByOne()
    {
        jumpsMade++;
        jumpsLeft--;
    }

    public override void changeVarValue(int difference)
    {
        throw new NotImplementedException();
    }

    public override int getVarValue()
    {
        throw new NotImplementedException();
    }

    public static new string ToString
    {
        get
        {
            return "WarpEffect";
        }
    }
}

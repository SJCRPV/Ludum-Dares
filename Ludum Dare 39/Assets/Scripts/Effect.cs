using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect {

    abstract public int getVarValue();

    abstract public void changeVarValue(int difference);
}

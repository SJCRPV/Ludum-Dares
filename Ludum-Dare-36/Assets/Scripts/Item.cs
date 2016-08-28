using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour {

    private importantVars importantVarsScript;
    protected playerInteraction playerScript;

    public abstract void applyEffects();

    public abstract void onPickup();
}

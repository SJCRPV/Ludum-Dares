using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour {

    private importantVars importantVarsScript;
    protected playerInteraction playerScript;

    public abstract void applyEffects();

    public void onPickup()
    {
        applyEffects();
        Destroy(this);
    }

	// Use this for initialization
	void Start () {
        importantVarsScript = GameObject.Find("Main Camera").GetComponent<importantVars>();
        playerScript = GameObject.Find("Player").GetComponent<playerInteraction>();
        importantVarsScript.itemLocationList.Add(this.transform);
    }
}

using UnityEngine;
using System.Collections;
using System;

public class launcher : Item {

    public override void applyEffects()
    {
        playerScript.setHasLauncher();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System;

public class launcher : Item {

    private int numOfBullets;

    private void defineNumOfBullets()
    {
        numOfBullets = UnityEngine.Random.Range(0, 30);
    }

    public override void applyEffects()
    {
        playerScript.setNumOfBullets(numOfBullets);
    }

    public override void onPickup()
    {
        applyEffects();
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        playerScript = GameObject.Find("Player").GetComponent<playerInteraction>();
        gameObject.name = "Launcher" + transform.position.x + transform.position.y;
	}
}

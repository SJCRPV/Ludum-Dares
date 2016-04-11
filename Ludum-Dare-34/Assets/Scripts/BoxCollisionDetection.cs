using UnityEngine;
using System.Collections;

public class BoxCollisionDetection : MonoBehaviour {

    CharacterStats characterStatsScript;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //10 is a default value. The amount should depend on what hits it. 
        characterStatsScript.decreaseHealth(10);
        characterStatsScript.decreaseForceMultiplier(10);
        //Debug.Log("Hit");
        Debug.Log(ToString());
    }

    override public string ToString()
    {
        return this.gameObject.name + " has " + characterStatsScript.health + " health.";
    }

    // Use this for initialization
    void Start () {
        characterStatsScript = GetComponent<CharacterStats>();
	}
}

using UnityEngine;
using System.Collections;

public class PointToPlayer : MonoBehaviour {

    private GameObject player;
    private GameObject target;

    void pointInRightDirection()
    {

    }

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        target = GameObject.Find("Target");
	}
	
	// Update is called once per frame
	void Update () {
        pointInRightDirection();
	}
}

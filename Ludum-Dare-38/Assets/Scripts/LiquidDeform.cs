using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDeform : Deform {

    [SerializeField]
    private GameObject waterPrefab;

    private GameObject waterInstance;

    public void deformLiquids(Vector3 point, float force, int forceRadius)
    {
        waterInstance = Instantiate(waterPrefab, point, Quaternion.identity);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

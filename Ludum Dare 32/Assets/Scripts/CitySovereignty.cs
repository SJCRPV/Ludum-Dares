using UnityEngine;
using System.Collections;

public class CitySovereignty : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.layer == 8 && this.gameObject.tag != "Owned by 2")
		{
			this.gameObject.tag = "Owned by 1";
		}
		else if(collider.gameObject.layer == 9 && this.gameObject.tag != "Owned by 1")
		{
			this.gameObject.tag = "Owned by 2";
		}
		else
		{

		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

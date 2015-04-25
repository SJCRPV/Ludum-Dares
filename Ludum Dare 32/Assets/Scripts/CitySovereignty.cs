using UnityEngine;
using System.Collections;

public class CitySovereignty : MonoBehaviour {

//	Battle battleScript;

	public bool isOccupied;

//	void runBattle()
//	{
//
//	}

	void whoOwns()
	{

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		//If Side 1 collides with the city and it's not owned by Side 2
		Debug.Log(collider.gameObject.layer);
		Debug.Log(this.gameObject.tag);
		if(collider.gameObject.layer == 13 && this.gameObject.tag != "Owned by 2")
		{
			this.gameObject.tag = "Owned by 1";
			Debug.Log(gameObject.tag);
			isOccupied = true;
			//Change to City Blue
		}
		//If Side 2 collides with the city and it's not owned by Side 1
		else if(collider.gameObject.layer == 13 && this.gameObject.tag != "Owned by 1")
		{
			this.gameObject.tag = "Owned by 2";
			Debug.Log(gameObject.tag);
			isOccupied = true;
			//Change to City Red
		}
//		//Else, duke it out! (Maybe not do this. It goes beyond the scope of what the script
//		//is supposed to do and you already have a CollisionHandler.
//		else
//		{
//			runBattle();
//		}
	}

	// Use this for initialization
	void Start () {
//		battleScript = GetComponent<Battle>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

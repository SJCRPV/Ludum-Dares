using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

	CharacterMove characterMoveScript;
	GameObject objectToMerge;

	private bool colliding;
	string colliderStore;

	void OnTriggerEnter2D(Collider2D collider)
	{
		//characterMoveScript.moving = true;
		colliding = true;
		if(collider.gameObject.name == "Map" || collider.gameObject.name == "City")
		{
			//collider.gameObject.tag = 
		}
		else
		{
			collider.gameObject.tag = "To Merge";
		}
		colliderStore = collider.gameObject.name;
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		colliding = false;
	}

	void mergeUnits()
	{
		objectToMerge = GameObject.FindGameObjectWithTag("To Merge");
		objectToMerge.transform.position = transform.position;
		characterMoveScript.moving = false;
	}

	void collisionResult()
	{
		if(colliderStore.Equals("Generic Soldier"))
		{
			//Debug.Log("*Bump*"); 
			mergeUnits();
		}
		else if(colliderStore.Equals("City"))
		{
			//Debug.Log("You terrorist...");
			//if(
		}
	}

	// Use this for initialization
	void Start () {
		characterMoveScript = GetComponent<CharacterMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if(colliding == true)
		{
			if(characterMoveScript.moving == false)
			{
				collisionResult();
			}
//			if(objectToMerge != null)
//				objectToMerge.gameObject.tag = "To Merge";
		}
		else
		{
			if(objectToMerge != null)
				objectToMerge.gameObject.tag = "Soldier";
		}
		if(objectToMerge != null)
		{
//			Debug.Log(objectToMerge.tag);
//			Debug.Log(objectToMerge.transform.position);
		}
	}
}

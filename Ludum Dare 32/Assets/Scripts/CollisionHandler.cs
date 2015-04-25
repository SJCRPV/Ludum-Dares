using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

	CharacterMove characterMoveScript;
	GameObject objectToMerge;
	Collider2D collidingObject;

	private bool collision;
	private int ownLayer;
	private int enemyLayer;
	//private int colliderStore;

	void whichIsEnemy()
	{
		if(gameObject.layer == 8)
		{
			enemyLayer = 9;
		}
		else
		{
			enemyLayer = 8;
		}
	}

	void fight()
	{

	}

	void mergeUnits()
	{
		objectToMerge = GameObject.FindGameObjectWithTag("To Merge");
		objectToMerge.transform.position = transform.position;
		characterMoveScript.moving = false;
	}

	void collisionResult()
	{
		switch(collidingObject.gameObject.layer)
		{
		//Own Layer
		case ownLayer:
			collidingObject.gameObject.tag = "To Merge";
			//Debug.Log(collider.gameObject.name + " has just been assigned the tag of: " + collider.gameObject.tag);
			mergeUnits();
			break;

		case enemyLayer:
			fight();
			break;

		//Map Layer
		case 11: 

			break;

		//City Layer
		case 12:

			break;

		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		//characterMoveScript.moving = true;
		collision = true;
		//colliderStore = collider.gameObject.layer;
		collidingObject = collider;

		collisionResult();
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		collision = false;
	}

	// Use this for initialization
	void Start () {
		characterMoveScript = GetComponent<CharacterMove>();
		ownLayer = gameObject.layer;
		whichIsEnemy();
	}
	
	// Update is called once per frame
	void Update () {
		if(collision == true)
		{
			if(characterMoveScript.moving == false)
			{
				collisionResult();
			}
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

using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

	CharacterMove characterMoveScript;

	private bool colliding;
	string colliderStore;

	void OnTriggerEnter2D(Collider2D collider)
	{
		colliding = true;
		Debug.Log(colliderStore = collider.gameObject.name);
	}
	void OnTriggerExit2D()
	{
		colliding = false;
	}

	void collisionResult()
	{
		if(colliderStore.Equals("Generic Soldier"))
		{
			Debug.Log("*Bump*");
		}
		else if(colliderStore.Equals("City"))
		{
			Debug.Log("You terrorist...");
		}
	}

	// Use this for initialization
	void Start () {
		characterMoveScript = GetComponent<CharacterMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if(colliding == true && characterMoveScript.moving == false)
		{
			collisionResult();
		}

	}
}

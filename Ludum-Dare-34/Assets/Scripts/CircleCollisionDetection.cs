using UnityEngine;
using System.Collections;

public class CircleCollisionDetection : MonoBehaviour {

    CircleCollider2D circleCollider;
    Rigidbody2D rigidBody;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Circle hit!");
        //Debug.Log(this.ToString());
    }

    void swapColliderStatus()
    {
        //Debug.Log("I received the message!");
        circleCollider.enabled = !circleCollider.enabled;

        rigidBody.AddForce(new Vector2(0,0));
    }

    override public string ToString()
    {
        return this.gameObject.name + ", son of: " + this.transform.parent.name;
    }

	// Use this for initialization
	void Start () {
        circleCollider = GetComponent<CircleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

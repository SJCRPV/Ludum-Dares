using UnityEngine;
using System.Collections;

public class BulletLifespan : MonoBehaviour {

    public float speed;

    private Vector2 moveVector;
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.x > GameObject.Find("MainChar").transform.position.x)
        {
            moveVector = transform.position;
            moveVector.x -= Time.deltaTime * speed;
            transform.position = moveVector;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}

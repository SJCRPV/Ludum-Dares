using UnityEngine;
using System.Collections;

public class StopFalling : MonoBehaviour {

	Vector3 stop;
	bool notFalling = false;

	// Use this for initialization
	void Start () {
		stop = new Vector3 (transform.position.x, -5f, transform.position.z);
	}

	void OnGUI()
	{
		if(notFalling)
		GUI.Label(new Rect(transform.position.x, transform.position.y, 250, 250), "I don't want to fall further! >: I");
	}


	void stopFalling()
	{
		notFalling = true;
		transform.position = stop;
		OnGUI ();
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5) {
			stopFalling();
		}
	}
}

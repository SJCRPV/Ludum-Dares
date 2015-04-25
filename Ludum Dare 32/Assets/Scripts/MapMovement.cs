using UnityEngine;
using System.Collections;

public class MapMovement : MonoBehaviour {

	Vector3 pos;
	public float speed;

	void Zoom()
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back 
		{
			if(Camera.main.orthographicSize < 6)
			{
				Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize+1, 1);
			}
		}
		
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			if(Camera.main.orthographicSize > 1)
			{
				Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize-1, 50);
			}
		}
	}

	void Movement()
	{
		pos = transform.position; 

		if(Camera.main.transform.position.x < -5)
		{
			pos.x = -Camera.main.orthographicSize;
		}
		else if(Camera.main.transform.position.x > 5)
		{
			pos.x = Camera.main.orthographicSize;
		}
		else
		{
			pos.x += Input.GetAxis("Horizontal") * speed;
		}

		if(Camera.main.transform.position.y < -5)
		{
			pos.y = -Camera.main.orthographicSize;
		}
		else if(Camera.main.transform.position.y > 5)
		{
			pos.y = Camera.main.orthographicSize;
		}
		else
		{
			pos.y += Input.GetAxis("Vertical") * speed;
		}

		transform.position = pos;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{ 
		Movement();
		Zoom();
	} 
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    
    [SerializeField]
    private float cameraRotation;
    [SerializeField]
    private int zoomOut;
    [SerializeField]
    private int zoomIn;
    [SerializeField]
    private float cameraSpeed;

    void rotateCamera()
    {
        //Try to smoothe this transition. The jump is disorienting
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * cameraRotation, Space.World);           
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(Vector3.up * cameraRotation, Space.World);
        }
    }

    void zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back 
        {
            if (Camera.main.orthographicSize <= zoomOut)
            {
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize + 1, 1);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            if (Camera.main.orthographicSize > zoomIn)
            {
                Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize - 1, 50);
            }
        }
    }

    void moveCamera()
    {
        //TODO: Does not take into account camera rotation
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, cameraSpeed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }
    }
	
    void centrePlayer()
    {
        gameObject.transform.position = new Vector3(GameObject.Find("Player").transform.position.x - 30, GameObject.Find("Player").transform.position.y + 25, GameObject.Find("Player").transform.position.z - 30);
    }

    private void Start()
    {
        //centrePlayer();
    }

	// Update is called once per frame
	void Update () {
        zoom();
        //moveCamera();
        rotateCamera();
	}
}

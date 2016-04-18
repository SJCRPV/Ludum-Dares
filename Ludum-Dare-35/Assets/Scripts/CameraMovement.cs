using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float cameraRotation;

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
            if (Camera.main.orthographicSize <= 20)
            {
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize + 1, 1);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            if (Camera.main.orthographicSize > 1)
            {
                Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize - 1, 50);
            }
        }
    }
	
    void centerPlayer()
    {
        gameObject.transform.position = new Vector3(GameObject.Find("Player").transform.position.x - 30, GameObject.Find("Player").transform.position.y + 25, GameObject.Find("Player").transform.position.z - 30);
    }

	// Update is called once per frame
	void Update () {
        zoom();
        rotateCamera();
        centerPlayer();
	}
}

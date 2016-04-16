using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

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
        gameObject.transform.position = GameObject.Find("Player").transform.position;
    }

	// Update is called once per frame
	void Update () {
        zoom();
        centerPlayer();
	}
}

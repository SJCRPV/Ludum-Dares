using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Camera gameCamera;
    private CharacterController characterController;

    public float getSpeed()
    {
        return speed;
    }

    void move()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        characterController.SimpleMove(moveDirection);
    }

	// Use this for initialization
	void Start () {
        gameCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        move();
        gameObject.transform.rotation = gameCamera.transform.rotation;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}

using UnityEngine;
using System.Collections;

public class PointToTarget : MonoBehaviour {

    public float arrowMovementSpeed;

    private GameObject player;
    private GameObject target;
    private Renderer targetRenderer;
    private CanvasRenderer arrowRenderer;
    private float topBorder;
    private float rightBorder;

    void pointInRightDirection()
    {
        if(targetRenderer.isVisible == false)
        {
            Vector3 temp = transform.position;
            //Center of the screen
            //transform.position = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);

            Vector3 distanceVectorToTarget = (player.transform.position - target.transform.position);
            Debug.DrawLine(player.transform.position, target.transform.position, Color.red);

            if ((transform.position.x <= player.transform.position.x + (topBorder / 2) && transform.position.x >= player.transform.position.x - (topBorder / 2)) || (transform.position.y <= player.transform.position.y + (rightBorder / 2) && transform.position.y >= player.transform.position.y - (rightBorder / 2)))
            {
                transform.position = Vector3.MoveTowards(transform.position, Camera.main.WorldToScreenPoint(target.transform.position), arrowMovementSpeed * Time.deltaTime);
            }











            ////If transform.position doesn't hit any of the camera edges
            //if ((transform.position.x <= player.transform.position.x + (topBorder / 2) && transform.position.x >= player.transform.position.x - (topBorder / 2)) || (transform.position.y <= player.transform.position.y + (rightBorder / 2) && transform.position.y >= player.transform.position.y - (rightBorder / 2)))

            //{
            //    transform.position = Vector3.MoveTowards(transform.position, Camera.main.WorldToScreenPoint(target.transform.position), arrowMovementSpeed * Time.deltaTime);
            //}

            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 50*Time.deltaTime);
            ////Debug.Log("Arrow position: " + transform.position);
            //if (transform.position.x >= player.transform.position.x + (topBorder / 2))
            //{
            //    Debug.Log("Hit the top border");
            //    temp.x = topBorder - 20;
            //    transform.position = temp;
            //}
            //if(transform.position.x <= player.transform.position.x - (topBorder / 2))
            //{
            //    Debug.Log("Hit the bottom border");
            //    temp.x = 20;
            //    transform.position = temp;
            //}
            //if(transform.position.y >= player.transform.position.y + (rightBorder / 2))
            //{
            //    Debug.Log("Hit the right border");
            //    temp.y = rightBorder - 20;
            //    transform.position = temp;
            //}
            //if(transform.position.y <= player.transform.position.y - (rightBorder / 2))
            //{
            //    Debug.Log("Hit the left border");
            //    temp.y = 20;
            //    transform.position = temp;
            //}

            //Debug.Log("Current position: " + transform.position);
        }
    }

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        target = GameObject.Find("Target");
        targetRenderer = target.GetComponent<Renderer>();
        arrowRenderer = GetComponent<CanvasRenderer>();
        topBorder = Camera.main.pixelHeight;
        rightBorder = Camera.main.pixelWidth;
    }
	
	// Update is called once per frame
	void Update () {
        pointInRightDirection();
	}
}

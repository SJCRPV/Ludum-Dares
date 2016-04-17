using UnityEngine;
using System.Collections;

public class PointToTarget : MonoBehaviour {

    public float arrowMovementSpeed;

    private GameObject player;
    private GameObject target;
    private Renderer targetRenderer;
    private Canvas canvas;
    private float topBorder;
    private float bottomBorder;
    private float rightBorder;
    private float leftBorder;

    void PointInRightDirection()
    {
        if(targetRenderer.isVisible == false)
        {
            //this is your object that you want to have the UI element hovering over
            

            //this is the ui element
            RectTransform UI_Element = GetComponent<RectTransform>();

            //first you need the RectTransform component of your canvas
            RectTransform CanvasRect = GetComponentInParent<RectTransform>();

            //then you calculate the position of the UI element
            //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(target.transform.position);
            Vector2 target_ScreenPosition = new Vector2(((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x)), ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y)));

            //now you can set the position of the ui element
            UI_Element.anchoredPosition = target_ScreenPosition;

            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, arrowMovementSpeed);
            Debug.DrawLine(player.transform.position, target.transform.position, Color.red);
        }
    }
    void pointInRightDirection()
    {
        if(targetRenderer.isVisible == false)
        {
            Vector3 temp = transform.position;
            //Center of the screen
            //transform.position = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);

            Vector3 distanceVectorToTarget = (player.transform.position - target.transform.position);
            Debug.DrawLine(player.transform.position, target.transform.position, Color.red);

            if ((transform.position.x <= topBorder && transform.position.x >= bottomBorder) || (transform.position.y <= rightBorder && transform.position.y >= leftBorder))
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, arrowMovementSpeed);
            }

            canvas.GetComponent<RectTransform>().anchorMin = Camera.main.WorldToViewportPoint(target.transform.position);
            canvas.GetComponent<RectTransform>().anchorMax = Camera.main.WorldToViewportPoint(target.transform.position);










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
        canvas = GetComponentInParent<Canvas>();
        topBorder = Camera.main.WorldToViewportPoint(player.transform.position).z + Camera.main.pixelHeight / 2;
        bottomBorder = Camera.main.WorldToViewportPoint(player.transform.position).z - Camera.main.pixelHeight / 2;
        rightBorder = Camera.main.WorldToViewportPoint(player.transform.position).x + Camera.main.pixelWidth / 2;
        leftBorder = Camera.main.WorldToViewportPoint(player.transform.position).x - Camera.main.pixelWidth / 2;
    }
	
	// Update is called once per frame
	void Update () {
        PointInRightDirection();
	}
}

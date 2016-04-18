using UnityEngine;
using System.Collections;

public class PointToTarget : MonoBehaviour {

    public float arrowMovementSpeed;

    private GameObject player;
    private GameObject target;

    void PointInRightDirection()
    {
        //this is the ui element
        RectTransform UI_Element = GetComponent<RectTransform>();

        //first you need the RectTransform component of your canvas
        RectTransform CanvasRect = GetComponentInParent<RectTransform>();

        //then you calculate the position of the UI element
        //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(target.transform.position);
        Vector2 target_ScreenPosition = new Vector2(((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)), ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        UI_Element.anchoredPosition = target_ScreenPosition;

        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, arrowMovementSpeed);
        Debug.DrawLine(player.transform.position, target.transform.position, Color.red);
        gameObject.transform.LookAt(target.transform.position);
    }

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        target = GameObject.Find("Target");
    }
	
	// Update is called once per frame
	void Update () {
        PointInRightDirection();
	}
}

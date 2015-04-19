using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
	
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Vector3 endPositionStore;
	private float distanceTravelled;
	private int distancePerAP;
	private RaycastHit2D isItThere;
	private float angle;
	private Vector2 angleInRad;
	private int startingLayer;

	public bool stackSelected;
	public bool mouseOnObject;
	public bool moving;
	public float characterSpeed;
	public float actionPoints;
	public LayerMask layerMask;

	public Vector3 getEndPosition()
	{
		return endPosition;
	}

	void unassignLerpVars()
	{
		moving = false;
	}

	void startLerping()
	{
		moving = true;
	}

	void setMovement()
	{
		//The fact that I'm denying the (0,0,0) vector may be causing problems with the 
		//first instantiation of the Generic Soldier being un-interactable until a 2nd
		//soldier is created
		if(endPositionStore != new Vector3(0,0,0))
		{
			//Debug.Log("Clicked the right mouse button!");
			startLerping();
			startPosition = transform.position;
			endPosition = Camera.main.ScreenToWorldPoint(endPositionStore);
			endPosition.z = transform.position.z;
		}
	}

	float calculateDistance()
	{
		Vector3 distanceCalc = transform.position - startPosition;
		distanceTravelled += Mathf.Sqrt( Mathf.Pow(distanceCalc.x,2) + Mathf.Pow(distanceCalc.y,2));

		return distanceTravelled;
	}

	void deductActionPoints()
	{
		if(moving)
		{
			if(calculateDistance() >= distancePerAP)
			{
				actionPoints--;
				distanceTravelled = 0;
			}
		}
	}

	void moveCharacter()
	{
		if(moving && actionPoints > 0)
		{
			transform.position = Vector3.MoveTowards(startPosition, endPosition, characterSpeed * Time.deltaTime);
			deductActionPoints();

			if(transform.position == endPosition)
			{
				unassignLerpVars();
			}
		}
	}

	void OnMouseOver()
	{
		mouseOnObject = true;
		if(Input.GetMouseButtonDown(0))
		{
			stackSelected = !stackSelected;
			if(stackSelected)
			{
				Debug.Log("Clicked on the object!");
				gameObject.layer = 13;
			}
			else
			{
				Debug.Log("Unselected the object!");
				gameObject.layer = startingLayer;
			}
		}
	}
	void OnMouseExit()
	{
		mouseOnObject = false;
	}
	
	// Use this for initialization
	void Start () {
		moving = false;
		distanceTravelled = 0;
		distancePerAP = 1;
		startingLayer = gameObject.layer;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			if(stackSelected == true && mouseOnObject == false)
			{
				Debug.Log("You de-selected the object.");
				stackSelected = false;
				gameObject.layer = startingLayer;
			}
		}
		if(Input.GetMouseButtonDown(1) && stackSelected == true)
		{
			endPositionStore = Input.mousePosition;
			angle = Vector2.Angle(transform.position, endPosition);
			angleInRad = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
			isItThere = Physics2D.Raycast(endPosition, angleInRad, Mathf.Infinity, layerMask);
//			Debug.DrawRay(transform.position, endPosition, Color.blue);
			Debug.Log("colided with " + isItThere.collider.name + " at layer " + isItThere.collider.gameObject.layer);
//			if(isItThere.Length > 0)
//			{
//				Debug.Log("There's something there!");
//				gameObject.tag = "To Merge";
//			}
//			else
//			{
//				gameObject.tag = "Soldier";
//			}
		}
		setMovement();
		moveCharacter();
	}
}

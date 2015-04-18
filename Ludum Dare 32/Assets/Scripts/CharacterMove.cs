using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
	
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Vector3 endPositionStore;
	private float distanceTravelled;
	private int distancePerAP;
	//private float timeSinceLerpStart;

	public bool stackSelected;
	public bool mouseOnObject;
	public bool moving;
	public float characterSpeed;
	public float actionPoints;

	public Vector3 getEndPosition()
	{
		return endPosition;
	}

	void unassignLerpVars()
	{
		moving = false;
		//timeSinceLerpStart = 0f;
	}

	void startLerping()
	{
		moving = true;
		//timeSinceLerpStart = Time.time;
	}

	void setMovement()
	{
		//if(Input.GetMouseButtonDown(1))
		if(endPositionStore != new Vector3(0,0,0))
		{
			//Debug.Log("Clicked the right mouse button!");
			//Debug.Log(Input.mousePosition);
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
			}
			else
			{
				Debug.Log("Unselected the object!");
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
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			if(stackSelected == true && mouseOnObject == false)
			{
				Debug.Log("You de-selected the object.");
				stackSelected = false;
			}
		}
		if(Input.GetMouseButtonDown(1) && stackSelected == true)
		{
			endPositionStore = Input.mousePosition;
		}
		setMovement();
		moveCharacter();
	}
}

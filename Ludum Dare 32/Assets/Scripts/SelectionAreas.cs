using UnityEngine;
using System.Collections;

public class SelectionAreas : MonoBehaviour {

	CharacterMove characterMoveScript;
	public GameObject genericPrefab;

	// Use this for initialization
	void Start () {
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(2))
		{
			genericPrefab = (GameObject)Instantiate(genericPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
			genericPrefab.gameObject.name = "Generic Soldier";
			Vector3 tempVect = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
			tempVect.z = 0;
			genericPrefab.transform.position = tempVect;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}

using UnityEngine;
using System.Collections;

public class TransparencyOnZoom : MonoBehaviour {

    private Camera gameCamera;
    private Ray ray;
    private RaycastHit hit;
    private int layerMask;

    void turnSemiTransparent()
    {
        Debug.Log("I can't see the player!");
    }

	// Use this for initialization
	void Start () {
        gameCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
     //   ray = new Ray(transform.position, GameObject.Find("Player").transform.position);
	    //if(Physics.Raycast(ray, out hit))
     //   {
     //       if (hit.collider.tag == "RealPlayer")
     //       {
     //           Debug.Log("Hit! " + hit.collider.name);
     //           Debug.DrawLine(ray.origin, Camera.main.transform.forward * 50000000, Color.red);
     //       }
     //       else
     //       {
     //           //turnSemiTransparent();
     //       }
     //   }
	}
}

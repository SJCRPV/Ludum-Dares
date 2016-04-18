using UnityEngine;
using System.Collections;

public class TransparencyOnZoom : MonoBehaviour {

    public Material transparencyMaterial;
    public Material normalMaterial;

    private GameObject[] buildings;
    private Renderer[] buildingsRenderer;

    void Start()
    {
        buildings = GameObject.FindGameObjectsWithTag("Building");
        buildingsRenderer = new Renderer[buildings.Length];
        if(buildings == null)
        {
            Debug.LogError("buildings found no objects with the tag 'Building'");
        }

        for(int i = 0; i < buildings.Length; i++)
        {
            buildingsRenderer[i] = buildings[i].GetComponent<Renderer>();
        }
    }

    void Update()
    {
        for(int i = 0; i < buildings.Length; i++)
        {
            if(buildingsRenderer[i].isVisible && Camera.main.orthographicSize <= 15)
            {
                buildingsRenderer[i].sharedMaterial = transparencyMaterial;
            }
            else
            {
                if (buildingsRenderer[i].sharedMaterial == transparencyMaterial)
                {
                    buildingsRenderer[i].sharedMaterial = normalMaterial;
                }
            }
        }
    }




















 //   private Camera gameCamera;
 //   private Ray ray;
 //   private RaycastHit hit;
 //   private int layerMask;

 //   void turnSemiTransparent()
 //   {
 //       Debug.Log("I can't see the player!");
 //   }

	//// Use this for initialization
	//void Start () {
 //       gameCamera = GetComponent<Camera>();
	//}
	
	//// Update is called once per frame
	//void Update () {
 //    //   ray = new Ray(transform.position, GameObject.Find("Player").transform.position);
	//    //if(Physics.Raycast(ray, out hit))
 //    //   {
 //    //       if (hit.collider.tag == "RealPlayer")
 //    //       {
 //    //           Debug.Log("Hit! " + hit.collider.name);
 //    //           Debug.DrawLine(ray.origin, Camera.main.transform.forward * 50000000, Color.red);
 //    //       }
 //    //       else
 //    //       {
 //    //           //turnSemiTransparent();
 //    //       }
 //    //   }
	//}
}

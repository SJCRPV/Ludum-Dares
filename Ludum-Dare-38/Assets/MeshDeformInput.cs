using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformInput : MonoBehaviour {

    [SerializeField]
    private float force = 5f;
    [SerializeField]
    private float forceOffset = 0.01f;

    private void handleInput(int buttonPressed)
    {
        if(buttonPressed == 1)
        {
            force *= -1;
        }

        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(inputRay, out hit))
        {
            MeshDeform deformer = hit.collider.GetComponent<MeshDeform>();
            if(deformer)
            {
                Vector3 point = hit.point;
                point += hit.normal * forceOffset;
                deformer.addDeformingForce(point, force);
            }
        }

        if(buttonPressed == 1)
        {
            force *= -1;
        }
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButton(0))
        {
            handleInput(0);
        }
        else if(Input.GetMouseButton(1))
        {
            handleInput(1);
        }
	}
}

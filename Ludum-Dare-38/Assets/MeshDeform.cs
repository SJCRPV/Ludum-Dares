using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDeform : MonoBehaviour {

    Mesh meshToDeform;
    Vector3[] originalVertices, displacedVertices, vertexVelocities;

    public void addForceToVertex(int index, Vector3 point, float force)
    {
        Vector3 pointToVertex = displacedVertices[index] - point;
        float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
        float velocity = attenuatedForce * Time.deltaTime;
        vertexVelocities[index] += pointToVertex.normalized * velocity;
    }

    public void addDeformingForce(Vector3 point, float force)
    {
        //Debug.DrawLine(Camera.main.transform.position, point, Color.red);
        //Debug.Log("Hai");
        for(int i = 0; i < displacedVertices.Length; i++)
        {
            addForceToVertex(i, point, force);
        }
    }

    private void updateVertex(int index)
    {
        Vector3 velocity = vertexVelocities[index];
        displacedVertices[index] += velocity * Time.deltaTime;
    }

	// Use this for initialization
	void Start () {
        meshToDeform = GetComponent<MeshFilter>().mesh;
        originalVertices = meshToDeform.vertices;
        displacedVertices = new Vector3[originalVertices.Length];
        vertexVelocities = new Vector3[originalVertices.Length];
        for (int i = 0; i < originalVertices.Length; i++)
        {
            displacedVertices[i] = originalVertices[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            for (int i = 0; i < displacedVertices.Length; i++)
            {
                updateVertex(i);
            }
            meshToDeform.vertices = displacedVertices;
            meshToDeform.RecalculateNormals();
        }
	}
}

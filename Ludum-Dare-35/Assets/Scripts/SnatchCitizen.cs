using UnityEngine;
using System.Collections;

public class SnatchCitizen : MonoBehaviour {

    public double minSnatchRadius;
    public float timeBeforeKill;

    private double closestCitizen;
    private int closestCitizenIndex;
    private GameObject citizenGrabbed;
    private GenerateCitizens citizenGenerator;
    private Renderer playerRenderer;

    private void kill()
    {
        Destroy(citizenGrabbed.gameObject, timeBeforeKill);
    }

    private void snatch()
    {
        if (Vector3.Distance(transform.position, citizenGrabbed.transform.position) < minSnatchRadius)
        {
            playerRenderer = GetComponent<Renderer>();
            playerRenderer.sharedMaterial = citizenGrabbed.GetComponent<Renderer>().sharedMaterial;
            Debug.Log("Your current material is: " + playerRenderer.sharedMaterial + "\nThe index of the citizen you killed was: " + closestCitizenIndex);
            Debug.Log("Your position at the time was: " + transform.position);
            citizenGrabbed.GetComponent<WanderAimlessly>().pausePath();
            citizenGrabbed.GetComponent<WanderAimlessly>().enabled = false;
            citizenGrabbed.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            citizenGrabbed.GetComponent<Rigidbody>().AddExplosionForce(3, transform.position, 4, 0, ForceMode.Impulse);
            //Basically: citizen[target].avoidPlayer.doIKnowPlayerFace();
            citizenGenerator.getCitizenAt(citizenGenerator.getTargetNum()).GetComponent<AvoidPlayer>().doIKnowPlayerFace(false);
            kill();
        }
        else
        {
            Debug.Log("Your distance to the nearest citizen was: " + Vector3.Distance(transform.position, citizenGrabbed.transform.position) + " and the minimum distance was: " + minSnatchRadius);
        }
    }

    private void determineNearestCitizen()
    {
        closestCitizenIndex = 0;
        citizenGrabbed = null;
        for (int i = 1; i < citizenGenerator.getCitizenPoolLength(); i++)
        {
            if (citizenGenerator.getCitizenAt(i) != null && Vector3.Distance(transform.position, citizenGenerator.getCitizenAt(i).transform.position) <= closestCitizen)
            {
                closestCitizen = Vector3.Distance(transform.position, citizenGenerator.getCitizenAt(i).transform.position);
                closestCitizenIndex = i;
            }
        }
        citizenGrabbed = citizenGenerator.getCitizenAt(closestCitizenIndex);
        Debug.Log("The nearest citizen is at: " + citizenGrabbed.transform.position);
    }

	// Use this for initialization
	void Start () {
        citizenGenerator = GameObject.Find("Map").GetComponent<GenerateCitizens>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButton("Snatch"))
        {
            Debug.Log("You pressed the Snatch button!");
            closestCitizen = Vector3.Distance(transform.position, citizenGenerator.getCitizenAt(0).transform.position);
            determineNearestCitizen();
            snatch();
        }
	}
}

using UnityEngine;
using System.Collections;

public class AvoidPlayer : MonoBehaviour {

    public float timeBeforeRelaxing;

    private WanderAimlessly wanderAimlesslyScript;
    private GameObject player;
    private bool knowsPlayerFace = true;
    private bool canRelax;
    private bool isRunning;
    private float timeBeforeRelaxingStore;

    public bool doIKnowPlayerFace()
    {
        return knowsPlayerFace;
    }
    public void doIKnowPlayerFace(bool answer)
    {
        knowsPlayerFace = answer;
        Debug.Log("Do I know the player's face? " + knowsPlayerFace);
    }

    void runAway()
    {
        isRunning = true;
        wanderAimlesslyScript.newPath(transform.position + (transform.position - player.transform.position).normalized * 20, player.GetComponent<PlayerMovement>().getSpeed());
    }

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Hai. You just got in.\n isRunning is " + isRunning + " by the way");
        if(knowsPlayerFace && isRunning == false && collider.name == "Player")
        {
            canRelax = false;
            timeBeforeRelaxing = timeBeforeRelaxingStore;
            runAway();

            Debug.Log("Saw the player! Eeek!");
            Debug.Log("Target's current position: " + transform.position + "\nPlayer's current Position: " + player.transform.position);
            Debug.Log("Distance between player and target: " + Vector3.Distance(transform.position, player.transform.position));
        }
    }
    void OnTriggerStay(Collider collider)
    {
        //Debug.Log("Hai. You just got in.\n isRunning is " + isRunning + " by the way");
        if (knowsPlayerFace && isRunning == false && collider.name == "Player")
        {
            canRelax = false;
            timeBeforeRelaxing = timeBeforeRelaxingStore;
            runAway();

            Debug.Log("Saw the player! Eeek!");
            Debug.Log("Target's current position: " + transform.position + "\nPlayer's current Position: " + player.transform.position);
            Debug.Log("Distance between player and target: " + Vector3.Distance(transform.position, player.transform.position));
        }
    }
    void OnTriggerExit()
    {
        canRelax = true;
    }

	// Use this for initialization
	void Start () {
        wanderAimlesslyScript = GetComponent<WanderAimlessly>();
        player = GameObject.Find("Player");
        timeBeforeRelaxingStore = timeBeforeRelaxing;
	}
	
	// Update is called once per frame
	void Update () {
        if(wanderAimlesslyScript.getAgent().remainingDistance <= 0)
        {
            isRunning = false;
        }

        if(canRelax)
        {
            timeBeforeRelaxing -= Time.deltaTime;
        }

        if (timeBeforeRelaxing <= 0)
        {
            Debug.Log("No longer running away. Returning to normal.");
            wanderAimlesslyScript.restartPath();
            timeBeforeRelaxing = timeBeforeRelaxingStore;
        }
    }
}

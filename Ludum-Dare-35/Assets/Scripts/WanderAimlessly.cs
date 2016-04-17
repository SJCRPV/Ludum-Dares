using UnityEngine;
using System.Collections;

public class WanderAimlessly : MonoBehaviour {

    public float waitingTime;
    public int speed;

    private float waitingTimeStore;
    private Vector3 pathCandidate;
    private NavMeshPath targetPath;
    private NavMeshAgent agent;

    public NavMeshAgent getAgent()
    {
        return agent;
    }

    void isPathValid()
    {
        agent.CalculatePath(pathCandidate, targetPath);
        if (targetPath.status == NavMeshPathStatus.PathInvalid || targetPath.status == NavMeshPathStatus.PathPartial)
        {
            pathCandidate.y++;
            isPathValid();
        }
    }

    public void newPath(Vector3 newPath, float newSpeed)
    {
        agent.ResetPath();
        targetPath = new NavMeshPath();
        Vector3 pathCandidate = newPath;
        isPathValid();
        agent.SetDestination(pathCandidate);
        agent.speed = newSpeed;
        waitingTime = waitingTimeStore;
    }
    void newPath()
    {
        agent.ResetPath();
        targetPath = new NavMeshPath();
        Vector3 pathCandidate = new Vector3(Random.Range(10, 490), 1, Random.Range(10, 490));
        isPathValid();
        agent.SetDestination(pathCandidate);
        agent.speed = speed;
        waitingTime = waitingTimeStore;
    }

    public bool isMoving()
    {
        if(Vector3.Distance(agent.velocity, Vector3.zero) == 0)
        {
            return false;
        }
        return true;
    }

    public void pausePath()
    {
        agent.Stop();
        agent.ResetPath();
    }

    public void restartPath()
    {
        newPath();
    }

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        waitingTimeStore = waitingTime;
        newPath();
	}
	
	// Update is called once per frame
	void Update () {
        if(agent.remainingDistance < 1)
        {
            waitingTime -= Time.deltaTime;
            if (waitingTime <= 0)
            {
                newPath();
            }
        }
	}
}

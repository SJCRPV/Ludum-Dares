using UnityEngine;
using System.Collections;

public class WanderAimlessly : MonoBehaviour {

    public float waitingTime;
    public int speed;

    private float waitingTimeStore;
    private Vector3 targetPoint;

    void newPath()
    {
        new WaitForSeconds(5);
        targetPoint = new Vector3(Random.Range(-90, 90), 0, Random.Range(-90, 90));
    }

	// Use this for initialization
	void Start () {
        waitingTimeStore = waitingTime;
        newPath();
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position, targetPoint) < 1)
        {
            waitingTime -= Time.deltaTime;
            if (waitingTime <= 0)
            {
                newPath();
                waitingTime = waitingTimeStore;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime * speed);
        }
	}
}

using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    public float distanceToPlayer;

    Vector3 newPosition;
    float playerXPosition;

    // Use this for initialization
    void Start()
    {
        newPosition = this.transform.position;
        playerXPosition = GameObject.Find("MainChar").transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > playerXPosition + distanceToPlayer)
        {
            newPosition.x -= speed * Time.deltaTime;
            this.transform.position = newPosition;
        }
        else
        {
            this.gameObject.layer = 10;
            BroadcastMessage("reachedCombatRange");
        }
    }
}

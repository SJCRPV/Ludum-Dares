using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {

    [SerializeField]
    private float timeBeforeDeath;

    private float timeBeforeDeathStore;
    private bool playerIsTouching;

    private void OnCollisionEnter(Collision collision)
    {
        playerIsTouching = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        playerIsTouching = false;
        timeBeforeDeath = timeBeforeDeathStore;
    }

    public bool isPlayerTouching()
    {
        return playerIsTouching;
    }

    private void Start()
    {
        timeBeforeDeathStore = timeBeforeDeath;
    }

    // Update is called once per frame
    void Update () {
        timeBeforeDeath -= Time.deltaTime;

        if(timeBeforeDeath <= 0 && playerIsTouching == false)
        {
            Destroy(this.gameObject);
        }
	}
}

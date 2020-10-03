using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTree : GameEntity, ICanBeInteractedWith
{
    [SerializeField]
    private float timeBetweenHarvestSteps = 0.5f;
    [SerializeField]
    private GameObject fire;

    private Coroutine ongoingHarvest;
    public void GetInteractedWith()
    {
        int currPlayerSTR = GameObject.Find("Player").GetComponent<Player>().STR;
        ongoingHarvest = StartCoroutine(Harvest(currPlayerSTR, timeBetweenHarvestSteps, "You whack at the tree for {0}. It is now at {1} health"));
    }

    private void Update()
    {
        if(Health <= 0)
        {
            Instantiate(fire, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

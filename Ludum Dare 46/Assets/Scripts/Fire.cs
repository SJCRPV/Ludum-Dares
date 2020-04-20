using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : GameEntity, IAmAffectedByTime, ICanBeInteractedWith
{
    [SerializeField]
    private float timeBetweenHarvestSteps = 0.5f;

    [SerializeField]
    private int numOfStepsBeforeEvent;

    public int NumOfStepsBeforeEvent => numOfStepsBeforeEvent;
    private Coroutine ongoingHarvest;

    public void GetInteractedWith()
    {
        int currPlayerDEX = GameObject.Find("Player").GetComponent<Player>().DEX;
        ongoingHarvest = StartCoroutine(Harvest(currPlayerDEX, timeBetweenHarvestSteps, "You absorb the flame into yours for {0}. It is now at {1} health"));
        GameObject.Find("Player").GetComponent<Player>().AlterHealth(Health);
    }

    public void TriggerTimeBasedEvent()
    {
        AlterHealth(-1);
    }

    new void Start()
    {
        base.Start();
        GameObject.Find("Player").GetComponent<TimeManager>().TimeSensitiveObjects.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

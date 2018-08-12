using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public enum Phases
    {
        Normal,
        Elementals,
        Ambushed,
        Resting,
        Looting,
        Boss
    }

    Hero hero;
    [SerializeField]
    private float timeBetweenPhases;
    private float timeBetweenPhasesStore;
    [SerializeField]
    private float timeBeforeHealthDrop;
    private float timeBeforeHealthDropStore;
    [SerializeField]
    private float timeBeforeEquipmentCheck;
    private float equipmentCheckTickStore;
    private int currentPhase;
    
    private void changeHeroBehaviour()
    {
        hero.changeBehaviour(currentPhase);
    }

    private void changePhase()
    {
        switch(currentPhase)
        {
            case (int)Phases.Resting:
                currentPhase = Random.Range((int)Phases.Normal, (int)Phases.Ambushed);           
                break;

            case (int)Phases.Normal:
            case (int)Phases.Elementals:
            case (int)Phases.Ambushed:
                currentPhase = Random.Range((int)Phases.Resting, (int)Phases.Boss);
                break;

            case (int)Phases.Boss:
                currentPhase = (int)Phases.Looting;
                break;

            case (int)Phases.Looting:
                currentPhase = Random.Range((int)Phases.Normal, (int)Phases.Resting);
                break;

            default:
                Debug.LogError("I'm using something I don't know about. What's the value for " + currentPhase + "?");
                break;
        }

        changeHeroBehaviour();
    }

	// Use this for initialization
	void Start () {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        timeBetweenPhasesStore = timeBetweenPhases;
        timeBeforeHealthDropStore = timeBeforeHealthDrop;
	}
	
    private void hurtHero()
    {
        hero.hurtHero();
    }

    private void updateTime()
    {
        timeBetweenPhases -= Time.deltaTime;
        timeBeforeHealthDrop -= Time.deltaTime;
        timeBeforeEquipmentCheck -= Time.deltaTime;
    }

	// Update is called once per frame
	void Update () {
        updateTime();

        if (timeBeforeHealthDrop <= 0)
        {
            hurtHero();
            timeBeforeHealthDrop = timeBeforeHealthDropStore;
        }

        if(timeBetweenPhases < 0)
        {
            changePhase();
            timeBetweenPhases = timeBetweenPhasesStore;
        }
	}
}

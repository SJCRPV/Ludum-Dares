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
    private float healthDropTick;
    private float healthDropTickStore;
    [SerializeField]
    private float equipmentCheckTick;
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
        timeBetweenPhasesStore = timeBetweenPhases;
	}
	
    private void hurtHero()
    {
        hero.hurtHero();
    }

    private void updateTime()
    {
        timeBetweenPhases -= Time.deltaTime;
        healthDropTick -= Time.deltaTime;
        equipmentCheckTick -= Time.deltaTime;
    }

	// Update is called once per frame
	void Update () {
        updateTime();

        if (healthDropTick <= 0)
        {
            hurtHero();
            healthDropTick = healthDropTickStore;
        }

        if(timeBetweenPhases < 0)
        {
            changePhase();
            timeBetweenPhases = timeBetweenPhasesStore;
        }
	}
}

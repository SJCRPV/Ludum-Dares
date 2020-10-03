using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntity : MonoBehaviour, IHaveHealth
{
    protected LogManager LogManager;
    protected TimeManager TimeManager;

    [SerializeField]
    private int health;
    public int Health => health;

    [SerializeField]
    private int maxHealth;
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    public void AlterHealth(int change)
    {
        health += change;
    }

    protected IEnumerator Harvest(int statValue, float timeBetweenSteps, string message)
    {
        while (health > 0)
        {
            AlterHealth(-statValue);
            LogManager.LogMessage(string.Format(message, statValue, Health));
            TimeManager.PassTime(1);
            yield return new WaitForSeconds(timeBetweenSteps);
        }
    }
    // Start is called before the first frame update
    protected void Start()
    {
        LogManager = GameObject.Find("Player").GetComponent<LogManager>();
        TimeManager = GameObject.Find("Player").GetComponent<TimeManager>();
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using System.Collections;

public class CharacterStats_Player : CharacterStats {

    private int healthStore;
    private float forceMultiplierStore;
    private float damageStore;

    public CharacterStats_Player(int health, float force, float damage) : base(health, force, damage)
    {
        health = healthStore;
        force = forceMultiplierStore;
        damage = damageStore;
    }

    override public void increaseHealth(int amount)
    {
        base.health += amount;
    }
    override public void decreaseHealth(int amount)
    {
        base.health -= amount;
    }

    override public void increaseForceMultiplier(int amount)
    {
        base.forceMultiplier += amount;
    }
    override public void decreaseForceMultiplier(int amount)
    {
        base.forceMultiplier -= amount;
    }

    void Start()
    {
        healthStore = health;
        forceMultiplierStore = forceMultiplier;
        damageStore = damage;
    }
}

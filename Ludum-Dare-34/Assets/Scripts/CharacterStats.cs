using UnityEngine;
using System.Collections;

public abstract class CharacterStats : MonoBehaviour {

    public int health;
    public float forceMultiplier;
    public float damage;

    public abstract void increaseHealth(int amount);
    public abstract void decreaseHealth(int amount);

    public abstract void increaseForceMultiplier(int amount);
    public abstract void decreaseForceMultiplier(int amount);

    public CharacterStats()
    {
        health = 10;
        forceMultiplier = 1;
    }
    public CharacterStats(int hp, float forceMult, float dam)
    {
        health = hp;
        forceMultiplier = forceMult;
        damage = dam;
    }
}

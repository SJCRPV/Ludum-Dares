using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStats : MonoBehaviour, IHaveHealth
{
    [SerializeField]
    private int strength;
    public int STR => strength;
    [SerializeField]
    private int speed;
    public int SPD => speed;
    [SerializeField]
    private int dexterity;
    public int DEX => dexterity;
    [SerializeField]
    private int fieldOfView;
    public int FOV => fieldOfView;
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
}

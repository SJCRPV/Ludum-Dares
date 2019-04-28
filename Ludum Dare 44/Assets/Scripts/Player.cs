using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField]
    public float DamageBonus { get; private set; } = 1f;
    [SerializeField]
    public float DefaultDamage { get; private set; } = 10f;
    [SerializeField]
    public float BeatLeniency { get; private set; } = 0f;
    [SerializeField]
    public float MaxHealth { get; private set; } = 100f;
    [SerializeField]
    public float CurrentHealth { get; private set; } = 100f;
    [SerializeField]
    public float DamageToSelfPerPunch { get; private set; } = 5f;

    private Slider healthBar;

    private bool amIDead()
    {
        return CurrentHealth <= 0;
    }

    public void hurtSelf()
    {
        CurrentHealth -= DamageToSelfPerPunch;
        healthBar.value = CurrentHealth / MaxHealth;
        if(amIDead())
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        healthBar = transform.Find("Canvas").transform.Find("PlayerHealth").GetComponent<Slider>();
        healthBar.value = CurrentHealth / MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

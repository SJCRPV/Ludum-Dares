using UnityEngine;
using System.Collections;
using System;

public class BasicDudeBehaviour : EnemyBehaviour
{
    public float timeBetweenAttacks;
    public float timeBetweenPatterns;

    float timeBetweenAttacksStore;
    float timeBetweenPatternsStore;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    int i = 0;

    public void resetAttackTime()
    {
        timeBetweenPatterns = timeBetweenPatternsStore;
        timeBetweenAttacks = timeBetweenAttacksStore;
    }

    public override void attack()
    {
        circleCollider.enabled = !circleCollider.enabled;
        spriteRenderer.enabled = !spriteRenderer.enabled;
        rigidBody.AddForce(new Vector2(0, 0));
    }

    public override void attackPattern()
    {
        timeBetweenAttacks -= Time.unscaledDeltaTime;
        if(timeBetweenAttacks <= 0)
        {
            attack();
            i++;
            Debug.Log(timeBetweenAttacksStore);
            timeBetweenAttacks = timeBetweenAttacksStore;
        }

        if(i >= 6)
        {
            i = 0;
            Debug.Log(timeBetweenPatternsStore);
            timeBetweenPatterns = timeBetweenPatternsStore;
        }
    }

    public override void reachedCombatRange()
    {
        reachedCombatRangeBool = true;
        this.gameObject.layer = 10;
    }

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeBetweenAttacksStore = timeBetweenAttacks;
        //Debug.Log("Store: " + timeBetweenAttacksStore);
        //Debug.Log("Real: " + timeBetweenAttacks);
        timeBetweenPatternsStore = timeBetweenPatterns;
    }

    void Update()
    {
        timeBetweenPatterns -= Time.unscaledDeltaTime;
        if(timeBetweenPatterns <= 0)
        {
            if(reachedCombatRangeBool)
            {
                attackPattern();
            }
        }
    }
}
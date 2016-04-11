using UnityEngine;
using System.Collections;
using System;

public class RangeDudeBehaviour : EnemyBehaviour {

    public GameObject bullet;
    public float newTimeBetweenAttacks;
    public float newTimeBetweenPatterns;
    public float timeBetweenBullets;

    private GameObject bulletInstance;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private float timeBetweenAttacksStore;
    private float timeBetweenPatternsStore;
    private float timeBetweenBulletsStore;
    int i = 0;

    public override void attack()
    {
        circleCollider.enabled = !circleCollider.enabled;
        spriteRenderer.enabled = !spriteRenderer.enabled;
        rigidBody.AddForce(new Vector2(0, 0));
    }

    public void fire()
    {
        bulletInstance = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        bulletInstance.gameObject.layer = 10;
        bulletInstance.gameObject.name = "Bullet";
    }

    public override void attackPattern()
    {
        if(reachedCombatRangeBool)
        {
            newTimeBetweenAttacks -= Time.unscaledDeltaTime;
            if (newTimeBetweenAttacks <= 0)
            {
                attack();
                i++;
                Debug.Log(timeBetweenAttacksStore);
                newTimeBetweenAttacks = timeBetweenAttacksStore;
            }

            if (i >= 6)
            {
                i = 0;
                Debug.Log(timeBetweenPatternsStore);
                newTimeBetweenPatterns = timeBetweenPatternsStore;
            }
        }
        else
        {
            timeBetweenBullets -= Time.unscaledDeltaTime;
            if (timeBetweenBullets <= 0)
            {
                fire();
                timeBetweenBullets = timeBetweenBulletsStore;
            }
        }
    }

    public override void reachedCombatRange()
    {
        reachedCombatRangeBool = true;
        this.gameObject.layer = 10;
    }

    // Use this for initialization
    void Start () {
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        timeBetweenAttacksStore = newTimeBetweenAttacks;
        timeBetweenPatternsStore = newTimeBetweenPatterns;
        timeBetweenBulletsStore = timeBetweenBullets;
    }
	
	// Update is called once per frame
	void Update ()
    {
        newTimeBetweenPatterns -= Time.unscaledDeltaTime;
        if (newTimeBetweenPatterns <= 0)
        {
            attackPattern();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private float health;
    public float Health { get { return health; } private set { health = value; } }
    private float initialHealth;
    private SpriteRenderer spriteRenderer;
    private Slider healthBar;
    [SerializeField]
    private Sprite sprite;

    private void amIDead()
    {
        if(Health <= 0)
        {
            EnemyManager.instance.NextEnemy();
            Destroy(gameObject);
        }
    }

    public void decrementHealth(float damage)
    {
        Health -= damage;
        healthBar.value = health / initialHealth;
        amIDead();
    }

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialHealth = health;
        healthBar = transform.Find("Canvas").transform.Find("EnemyHealth").GetComponent<Slider>();
        healthBar.value = 1f;
        spriteRenderer.sprite = sprite;
	}
}

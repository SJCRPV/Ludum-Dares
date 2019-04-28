using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private float health;
    public float Health { get { return health; } private set { health = value; } }
    [SerializeField]
    private Sprite sprite;

    private float initialHealth;
    private SpriteRenderer spriteRenderer;
    private Slider healthBar;
    private Text healthNumbers;

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
        healthNumbers.text = string.Format("{0}/{1}", Health, initialHealth);
        amIDead();
    }

	// Use this for initialization
	public void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialHealth = health;
        healthBar = transform.Find("Canvas").transform.Find("EnemyHealth").GetComponent<Slider>();
        healthBar.value = 1f;
        healthNumbers = transform.Find("Canvas").transform.Find("EnemyHealth").transform.Find("HealthNumbers").GetComponent<Text>();
        healthNumbers.text = string.Format("{0}/{1}", Health, initialHealth);
        spriteRenderer.sprite = sprite;
	}
}

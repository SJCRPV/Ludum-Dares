using UnityEngine;
using System.Collections;

public abstract class EnemyBehaviour : MonoBehaviour {

    public bool reachedCombatRangeBool;
    [HideInInspector]
    public CircleCollider2D circleCollider;

    public abstract void reachedCombatRange();
    public abstract void attack();
    public abstract void attackPattern();

	// Use this for initialization
	void Start () {
        reachedCombatRangeBool = false;
	}
}

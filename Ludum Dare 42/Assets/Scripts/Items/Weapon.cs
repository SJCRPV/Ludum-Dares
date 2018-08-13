using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

    [SerializeField]
    private int attack;
    [SerializeField]
    private int dps;
    [SerializeField]
    private bool isRanged;
    [SerializeField]
    private string itemType;
    [SerializeField]
    private string itemElement;

    public void Start()
    {
        createWeapon(attack, dps, isRanged, itemType, itemElement);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : Item {

    [SerializeField]
    private int defence;
    [SerializeField]
    private string itemSlot;
    [SerializeField]
    private string itemType;
    [SerializeField]
    private string itemElement;

    public void Start()
    {
        createArmour(defence, itemSlot, itemType, itemElement);
    }
}

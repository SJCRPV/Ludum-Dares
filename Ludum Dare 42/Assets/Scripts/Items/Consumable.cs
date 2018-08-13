using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item {

    [SerializeField]
    private int buffImpact;
    [SerializeField]
    private bool isConsumable;
    [SerializeField]
    private string itemType;
    [SerializeField]
    private string itemElement;

    public void Start()
    {
        createConsumable(buffImpact, isConsumable, itemType, itemElement);
    }
}

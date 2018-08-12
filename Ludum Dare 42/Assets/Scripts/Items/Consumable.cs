using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item {
    
    public Consumable(int nHealthRegen, bool nIsConsumable, string nItemType, string nItemElement) : base(nHealthRegen, nIsConsumable, nItemType, nItemElement)
    { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item {
    
    public Consumable(int nBuffImpact, bool nIsConsumable, string nItemType, string nItemElement) : base(nBuffImpact, nIsConsumable, nItemType, nItemElement)
    { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

    public Weapon(int nAttack, int nDps, bool nIsRanged, string nItemType, string nItemElement) : base(nAttack, nDps, nIsRanged, nItemType, nItemElement)
    { }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : World
{
    public int Attack { get; private set; }
    public int Defence { get; private set; }
    public float Dps { get; private set; }
    public int BuffImpact { get; private set; }
    public bool IsConsumable { get; private set; }
    public bool IsRanged { get; private set; }
    public string ItemSlot { get; private set; }
    public int ItemType { get; private set; }
    public int ItemElement { get; private set; }

    public void createWeapon(int nAttack, int nDps, bool nIsRanged, string nItemType, string nItemElement)
    {
        //Weapon
        Attack = nAttack;
        Dps = nDps;
        IsRanged = nIsRanged;
        ItemType = getNameNumber(typeof(ItemTypes), nItemType);
        ItemElement = getNameNumber(typeof(Elements), nItemElement);
    }

    public void createArmour(int nDefence, string nItemSlot, string nItemType, string nItemElement)
    {
        //Armour 
        Defence = nDefence;
        ItemSlot = nItemSlot;
        ItemType = getNameNumber(typeof(ItemTypes), nItemType);
        ItemElement = getNameNumber(typeof(Elements), nItemElement);
    }

    public void createConsumable(int nBuffImpact, bool nIsConsumable, string nItemType, string nItemElement)
    {
        //Consumables
        BuffImpact = nBuffImpact;
        IsConsumable = nIsConsumable;
        ItemType = getNameNumber(typeof(ItemTypes), nItemType);
        ItemElement = getNameNumber(typeof(Elements), nItemElement);
    }
}
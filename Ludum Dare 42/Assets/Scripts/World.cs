using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public enum Elements
    {
        Fire,
        Ice,
        Electric,
        Toxic,
        Earth,
        Normal
    }

    public enum ItemTypes
    {
        Sword,
        Axe,
        Scythe,
        Bow,
        Crossbow,
        Potion,
        FirePotion,
        IcePotion,
        ElectricPotion,
        ToxicPotion,
        EarthPotion,
        Helmet,
        Chestplate,
        Greaves,
        Boots,
        Gold
    };

    protected int getNameNumber(Type type, string itemType)
    {
        return (int)Enum.Parse(type, itemType);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public enum Elements
    {
        Normal,
        Fire,
        Ice,
        Electric,
        Toxic,
        Earth
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

    protected int getOppositeElement(int element)
    {
        switch (element)
        {
            case (int)Elements.Earth:
                return (int)Elements.Toxic;

            case (int)Elements.Electric:
                return (int)Elements.Normal;

            case (int)Elements.Fire:
                return (int)Elements.Ice;

            case (int)Elements.Ice:
                return (int)Elements.Fire;

            case (int)Elements.Toxic:
                return (int)Elements.Earth;

            default:
                Debug.LogError("I got an element I don't understand. What does " + element + " stand for?");
                return -1;
        }
    }
}

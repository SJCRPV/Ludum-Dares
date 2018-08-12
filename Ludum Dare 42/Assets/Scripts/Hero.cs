using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : World {

    //Equiped Items
    public struct Weapons
    {
        public Item primaryWeapon;
        public Item secondaryWeapon;
    }

    public struct Armour
    {
        public Item helmet;
        public Item chestPlate;
        public Item greaves;
        public Item shoes;
    }

    public Weapons weapons;
    public Armour armour;
    public Item buff;
    Behaviour behaviour;

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int health;
    [SerializeField]
    private int autoPotHP;
    [SerializeField]
    private int currBehaviour;

    private void useConsumable(Item item)
    {

    }

    private void swapArmour(Item item)
    {
        if(item.ItemSlot.Equals("Helmet"))
        {
            Instantiate(armour.helmet);
            armour.helmet = item;
            behaviour.helmetNeedsSwap = false;
        }
        else if (item.ItemSlot.Equals("Chest Plate"))
        {
            Instantiate(armour.chestPlate);
            armour.chestPlate = item;
            behaviour.chestNeedsSwap = false;
        }
        else if (item.ItemSlot.Equals("Greaves"))
        {
            Instantiate(armour.greaves);
            armour.greaves = item;
            behaviour.greavesNeedsSwap = false;
        }
        else if (item.ItemSlot.Equals("Shoes"))
        {
            Instantiate(armour.shoes);
            armour.shoes = item;
            behaviour.shoesNeedsSwap = false;
        }
    }

    private void swapWeapon(Item item)
    {
        if(item.IsRanged)
        {
            Instantiate(weapons.secondaryWeapon);
            weapons.secondaryWeapon = item;
            behaviour.secondaryNeedsSwap = false;
        }
        else
        {
            Instantiate(weapons.primaryWeapon);
            weapons.primaryWeapon = item;
            behaviour.primaryNeedsSwap = false;
        }
    }

    private void processTheItem(Item item)
    {
        if(item.GetType() == typeof(Weapon))
        {
            swapWeapon(item);
        }
        else if(item.GetType() == typeof(Armour))
        {
            swapArmour(item);
        }
        else if(item.GetType() == typeof(Consumable))
        {
            useConsumable(item);
        }
    }

    public void receiveItem(Item item)
    {
        processTheItem(item);
    }

    public void hurtHero()
    {
        health -= behaviour.getHealthDecreaseStep();
    }

    public void changeBehaviour(int newBehaviour)
    {
        behaviour.changeBehaviour(newBehaviour);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

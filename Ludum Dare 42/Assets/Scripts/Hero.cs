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
    private float timeBetweenPotCheck;
    private float timeBetweenPotCheckStore;
    [SerializeField]
    private int currBehaviour;
    private UI UIScript;
    private Inventory inventoryScript;

    private float itemEffectivness(int itemElement)
    {
        int enemyElement = EnemyManager.CurrentGroup[0].Element;
        if(itemElement == enemyElement)
        {
            return 1.5f;
        }
        else if(itemElement == getOppositeElement(enemyElement))
        {
            return 0.5f;
        }
        else
        {
            return 1f;
        }
    }

    private float totalArmourDefence()
    {
        float helmet = armour.helmet.Defence * itemEffectivness(armour.helmet.ItemElement);
        float chestPlate = armour.chestPlate.Defence * itemEffectivness(armour.chestPlate.ItemElement);
        float greaves = armour.greaves.Defence * itemEffectivness(armour.greaves.ItemElement);
        float shoes = armour.shoes.Defence * itemEffectivness(armour.shoes.ItemElement);

        return helmet + chestPlate + greaves + shoes;
    }

    public void hurtHero()
    {
        float result = (behaviour.getHealthDecreaseStep() - totalArmourDefence()) / itemEffectivness(buff.ItemElement);

        health -= Mathf.RoundToInt(result);
    }

    public void healHero(int amount)
    {
        health += amount;
    }

    private void useConsumable(Item item)
    {
        if(item.ItemElement == (int)Elements.Normal)
        {
            healHero(item.BuffImpact);
            return;
        }
        
        int oppositeElement = getOppositeElement(item.ItemElement);

        buff = item;
        UIScript.changeBuffs(item.ItemElement, oppositeElement, item.BuffImpact);

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

    public void changeBehaviour(int newBehaviour)
    {
        behaviour.changeBehaviour(newBehaviour);
    }

    private void checkForArmourSwapNeed()
    {
        if (behaviour.helmetNeedsSwap)
        {
            Inventory.swapQueue.Add(armour.helmet);
        }
        if (behaviour.chestNeedsSwap)
        {
            Inventory.swapQueue.Add(armour.chestPlate);
        }
        if (behaviour.greavesNeedsSwap)
        {
            Inventory.swapQueue.Add(armour.greaves);
        }
        if (behaviour.shoesNeedsSwap)
        {
            Inventory.swapQueue.Add(armour.shoes);
        }
    }

    private void checkForWeaponSwapNeed()
    {
        if(behaviour.primaryNeedsSwap)
        {
            Inventory.swapQueue.Add(weapons.primaryWeapon);
        }

        if(behaviour.secondaryNeedsSwap)
        {
            Inventory.swapQueue.Add(weapons.secondaryWeapon);
        }
    }

    private void checkForPotionNeed()
    {
        if (health < autoPotHP)
        {
            Item potion = null;
            timeBetweenPotCheck -= Time.deltaTime;
            if (timeBetweenPotCheck < 0)
            {
                potion = inventoryScript.fetchNearestPotion();
                if (potion == null)
                {
                    timeBetweenPotCheck = timeBetweenPotCheckStore;
                }
                else
                {
                    processTheItem(potion);
                    timeBetweenPotCheck = -1;
                }
            }
        }
    }

	// Use this for initialization
	void Start () {
        UIScript = GameObject.Find("Canvas").GetComponent<UI>();
        inventoryScript = GameObject.Find("Inventory").GetComponent<Inventory>();
        timeBetweenPotCheckStore = timeBetweenPotCheck;
        timeBetweenPotCheck = -1;

    }
	
	// Update is called once per frame
	void Update () {
        checkForPotionNeed();
        checkForWeaponSwapNeed();
        checkForArmourSwapNeed();
	}
}

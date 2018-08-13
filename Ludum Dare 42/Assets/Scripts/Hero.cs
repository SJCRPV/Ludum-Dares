using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    //Equiped Items
    public struct EquippedWeapons
    {
        public GameObject primaryWeapon;
        public GameObject secondaryWeapon;
    }

    public struct EquippedArmour
    {
        public GameObject helmet;
        public GameObject chestPlate;
        public GameObject greaves;
        public GameObject shoes;
    }

    public EquippedWeapons weapons;
    public EquippedArmour armour;
    public GameObject buff;
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
    private World worldScript;

    private float itemEffectivness(int itemElement)
    {
        int enemyElement = EnemyManager.CurrentGroup[0].Element;
        if(itemElement == enemyElement)
        {
            return 1.5f;
        }
        else if(itemElement == worldScript.getOppositeElement(enemyElement))
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
        float helmet = armour.helmet.GetComponent<Armour>().Defence * itemEffectivness(armour.helmet.GetComponent<Armour>().ItemElement);
        float chestPlate = armour.chestPlate.GetComponent<Armour>().Defence * itemEffectivness(armour.chestPlate.GetComponent<Armour>().ItemElement);
        float greaves = armour.greaves.GetComponent<Armour>().Defence * itemEffectivness(armour.greaves.GetComponent<Armour>().ItemElement);
        float shoes = armour.shoes.GetComponent<Armour>().Defence * itemEffectivness(armour.shoes.GetComponent<Armour>().ItemElement);

        return helmet + chestPlate + greaves + shoes;
    }

    public void hurtHero()
    {
        float result = (behaviour.getHealthDecreaseStep() - totalArmourDefence()) / itemEffectivness(buff.GetComponent<Consumable>().ItemElement);

        health -= Mathf.RoundToInt(result);
    }

    public void healHero(int amount)
    {
        health += amount;
    }

    private void useConsumable(GameObject item)
    {
        Consumable itemConsumable = item.GetComponent<Consumable>();
        if(itemConsumable.ItemElement == (int)World.Elements.Normal)
        {
            healHero(itemConsumable.BuffImpact);
            return;
        }
        
        int oppositeElement = worldScript.getOppositeElement(itemConsumable.ItemElement);

        buff = item;
        UIScript.changeBuffs(itemConsumable.ItemElement, oppositeElement, itemConsumable.BuffImpact);

    }

    private void swapArmour(GameObject item)
    {
        GameObject previousItem;
        Armour itemArmour = item.GetComponent<Armour>();
        if (itemArmour.ItemSlot.Equals("Helmet"))
        {
            previousItem = armour.helmet;
            armour.helmet = item;
            behaviour.helmetNeedsSwap = false;
        }
        else if (itemArmour.ItemSlot.Equals("Chest Plate"))
        {
            previousItem = armour.chestPlate;
            armour.chestPlate = item;
            behaviour.chestNeedsSwap = false;
        }
        else if (itemArmour.ItemSlot.Equals("Greaves"))
        {
            previousItem = armour.greaves;
            armour.greaves = item;
            behaviour.greavesNeedsSwap = false;
        }
        else if (itemArmour.ItemSlot.Equals("Shoes"))
        {
            previousItem = armour.shoes;
            armour.shoes = item;
            behaviour.shoesNeedsSwap = false;
        }
        else
        {
            previousItem = null;
            Debug.LogError("I don't know what piece of armour I'm supposed to swap with. Have a look:\n" + itemArmour.ItemSlot);
        }

        previousItem.SetActive(true);
    }

    private void swapWeapon(GameObject item)
    {
        GameObject previousItem;
        if(item.GetComponent<Weapon>().IsRanged)
        {
            previousItem = weapons.secondaryWeapon;
            weapons.secondaryWeapon = item;
            behaviour.secondaryNeedsSwap = false;
        }
        else
        {
            previousItem = weapons.primaryWeapon;
            weapons.primaryWeapon = item;
            behaviour.primaryNeedsSwap = false;
        }

        previousItem.SetActive(true);
    }

    private void processTheItem(GameObject item)
    {
        if(item.GetComponent<Weapon>() != null)
        {
            swapWeapon(item);
        }
        else if(item.GetComponent<Armour>() != null)
        {
            swapArmour(item);
        }
        else if(item.GetComponent<Consumable>() != null)
        {
            useConsumable(item);
        }
        else
        {
            Debug.LogError("I couldn't tell what this was. Have a look: " + item.ToString());
        }
    }

    public void receiveItem(GameObject item)
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
            GameObject potion = null;
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

    private void equipDefaultGear()
    {
        weapons.secondaryWeapon = worldScript.getItemGOAt(3);
        weapons.primaryWeapon = worldScript.getItemGOAt(0);
    }

	// Use this for initialization
	void Start () {
        UIScript = GameObject.Find("Canvas").GetComponent<UI>();
        inventoryScript = GameObject.Find("Inventory").GetComponent<Inventory>();
        worldScript = GameObject.Find("World").GetComponent<World>();
        behaviour = GetComponent<Behaviour>();
        timeBetweenPotCheckStore = timeBetweenPotCheck;
        timeBetweenPotCheck = -1;
        equipDefaultGear();
    }
	
	// Update is called once per frame
	void Update () {
        checkForPotionNeed();
        checkForWeaponSwapNeed();
        checkForArmourSwapNeed();
	}
}

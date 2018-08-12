using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour {

    Hero heroScript;
    UI UIScript;

    //Behaviour variables
    [SerializeField]
    public bool helmetNeedsSwap;
    [SerializeField]
    public bool chestNeedsSwap;
    [SerializeField]
    public bool greavesNeedsSwap;
    [SerializeField]
    public bool shoesNeedsSwap;
    [SerializeField]
    public bool primaryNeedsSwap;
    [SerializeField]
    public bool secondaryNeedsSwap;
    [SerializeField]
    public bool isRegeneratingHealth;
    [SerializeField]
    public bool hasRightWeapon;
    [SerializeField]
    public bool isPickingUpItems;
    [SerializeField]
    public float mistakeProbability;
    [SerializeField]
    public float healthDecreaseRate;
    [SerializeField]
    public int healthDecreaseStep;
    [SerializeField]
    public float weaponSwapRate;
    [SerializeField]
    public float armourSwapRate;

    public int getHealthDecreaseStep()
    {
        return healthDecreaseStep;
    }

    private void checkArmour()
    {
        int element = EnemyManager.CurrentGroup[0].Element;
        helmetNeedsSwap = heroScript.armour.helmet.ItemElement != element;
        chestNeedsSwap = heroScript.armour.chestPlate.ItemElement != element;
        greavesNeedsSwap = heroScript.armour.greaves.ItemElement != element;
        shoesNeedsSwap = heroScript.armour.shoes.ItemElement != element;
    }

    private void checkWeapons()
    {
        int element = EnemyManager.CurrentGroup[0].Element;
        primaryNeedsSwap = heroScript.weapons.primaryWeapon.ItemElement != element;
        secondaryNeedsSwap = heroScript.weapons.secondaryWeapon.ItemElement != element;
    }

    private void checkEquipment()
    {
        checkWeapons();
        checkArmour();
    }

    private void setArmourChange(bool value)
    {
        helmetNeedsSwap = value;
        chestNeedsSwap = value;
        greavesNeedsSwap = value;
        shoesNeedsSwap = value;
    }

    private void setWeaponChange(bool value)
    {
        primaryNeedsSwap = value;
        secondaryNeedsSwap = value;
    }

    private void setNormal()
    {
        setWeaponChange(false);
        setArmourChange(false);
        isRegeneratingHealth = false;
        hasRightWeapon = true;
        isPickingUpItems = false;
        mistakeProbability = 0.1f;
        healthDecreaseRate = 0.1f;
        healthDecreaseStep = 5;
        weaponSwapRate = 0.1f;
        armourSwapRate = 0;
        UIScript.changeCurrentEvent("The Hero is currently fighting mobs.");
    }

    private void setBossFight()
    {
        checkEquipment();
        isRegeneratingHealth = false;
        hasRightWeapon = false;
        isPickingUpItems = false;
        mistakeProbability = 0.25f;
        healthDecreaseRate = 0.05f;
        healthDecreaseStep = 25;
        weaponSwapRate = 0.4f;
        armourSwapRate = 0;
        UIScript.changeCurrentEvent("The Hero is currently fighting a boss. Pay attention.");
    }

    private void setResting()
    {
        setWeaponChange(false);
        setArmourChange(false);
        isRegeneratingHealth = true;
        hasRightWeapon = true;
        isPickingUpItems = false;
        mistakeProbability = 0;
        healthDecreaseRate = 0;
        healthDecreaseStep = 0;
        weaponSwapRate = 0;
        armourSwapRate = 0;
        UIScript.changeCurrentEvent("The Hero is sleeping. Relax.");
    }

    private void setLooting()
    {
        setWeaponChange(false);
        setArmourChange(false);
        isRegeneratingHealth = false;
        hasRightWeapon = true;
        isPickingUpItems = true;
        mistakeProbability = 0;
        healthDecreaseRate = 0;
        healthDecreaseStep = 0;
        weaponSwapRate = 0;
        armourSwapRate = 0;
        UIScript.changeCurrentEvent("The Hero is looting dead bodies. Flood incoming.");
    }

    private void setElementals()
    {
        checkEquipment();
        isRegeneratingHealth = false;
        hasRightWeapon = false;
        isPickingUpItems = false;
        mistakeProbability = 0.25f;
        healthDecreaseRate = 0.05f;
        healthDecreaseStep = 25;
        weaponSwapRate = 0.4f;
        armourSwapRate = 0;
        UIScript.changeCurrentEvent("The Hero is duking out against special mobs. Adjust accordingly.");
    }

    private void setAmbushed()
    {
        setWeaponChange(true);
        setArmourChange(true);
        isRegeneratingHealth = false;
        hasRightWeapon = false;
        isPickingUpItems = false;
        mistakeProbability = 0.5f;
        healthDecreaseRate = 0.3f;
        healthDecreaseStep = 10;
        weaponSwapRate = 0.5f;
        armourSwapRate = 0.5f;
        UIScript.changeCurrentEvent("The Hero is being ambushed! Don't panic!");
    }

    public void changeBehaviour(int newBehaviour)
    {
        switch (newBehaviour)
        {
            case (int)TimeManager.Phases.Normal:
                setNormal();
                break;

            case (int)TimeManager.Phases.Elementals:
                setElementals();
                break;

            case (int)TimeManager.Phases.Ambushed:
                setAmbushed();
                break;

            case (int)TimeManager.Phases.Resting:
                setResting();
                break;

            case (int)TimeManager.Phases.Looting:
                setLooting();
                break;

            case (int)TimeManager.Phases.Boss:
                setBossFight();
                break;

            default:
                Debug.LogError("I got a behaviour I don't understand. What is " + newBehaviour + " supposed to be?");
                break;
        }
    }

    // Use this for initialization
    void Start () {
        heroScript = GetComponent<Hero>();
        UIScript = GameObject.Find("Canvas").GetComponent<UI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

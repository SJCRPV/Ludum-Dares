using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionWithGod : MonoBehaviour {

    public static InteractionWithGod instance;

    [SerializeField]
    private float damageBonusIncrement;
    [SerializeField]
    private float beatLeniencyIncrement;
    [SerializeField]
    private float maxHealthLoss;

    private GameObject endLevelScreen;
    public bool IsInteractingWithGod { get { return endLevelScreen.activeSelf; } set { endLevelScreen.SetActive(value); } }

    public void closeInteractionScreen()
    {
        IsInteractingWithGod = false;
        BeatConstructor.instance.makeRandomBeat();
        BeatManager.instance.moveToNextBeat();
        BeatManager.instance.IsDroppingBeats = true;
        Player.instance.CurrentHealth = Player.instance.MaxHealth;
    }

    public void upgradeAttackDamage()
    {
        Player.instance.DamageBonus += damageBonusIncrement;
        Player.instance.MaxHealth -= maxHealthLoss;
        closeInteractionScreen();
    }

    public void upgradeBeatLeniency()
    {
        Player.instance.BeatLeniency += beatLeniencyIncrement;
        Player.instance.MaxHealth -= maxHealthLoss;
        closeInteractionScreen();
    }

	// Use this for initialization
	void Start () {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        endLevelScreen = GameObject.Find("EndLevelScreen");
        GameObject.Find("GainAttackDamageBtn").transform.GetChild(0).GetComponent<Text>().text = string.Format("{0} more damage multiplier\nLose {1} max health", damageBonusIncrement, maxHealthLoss);
        GameObject.Find("GainBeatLeniencyBtn").transform.GetChild(0).GetComponent<Text>().text = string.Format("Beats are {0} more lenient\nLose {1} max health", beatLeniencyIncrement, maxHealthLoss);
        endLevelScreen.SetActive(false);
    }
}

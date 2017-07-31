using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    private GameObject HUDObj;
    private Button warpBtn;
    private Text powerLeftTxt;
    private Text livesLeftTxt;
    private Text livesLostTxt;
    private Text moraleTxt;

    public void flipHUDVis()
    {
        HUDObj.SetActive(!HUDObj.activeSelf);
    }
    public void updatePower()
    {
        powerLeftTxt.text = "Power Left: " + PowerEffect.staticGetVarValue();
    }
    public void updateLivesLeft()
    {
        livesLeftTxt.text = "Lives Left: " + LivesEffect.staticGetLivesRemaining();
    }
    public void updateLivesLost()
    {
        livesLostTxt.text = "Lives Lost: " + LivesEffect.staticGetLivesLost();
    }
    public void updateMoraleText()
    {
        moraleTxt.text = "Current Morale: " + MoraleEffect.staticGetMoraleValue();
    }

    private void setDefaultValues()
    {
        powerLeftTxt.text = "Power Left: " + PowerEffect.staticGetVarValue();
        livesLeftTxt.text = "Lives Left: " + LivesEffect.staticGetLivesRemaining();
        livesLostTxt.text = "Lives Lost: " + LivesEffect.staticGetLivesLost();
        //TODO: Morale number interpreter
        moraleTxt.text = "Morale: " + MoraleEffect.staticGetMoraleValue();
    }

    // Use this for initialization
    void Start()
    {
        HUDObj = GameObject.Find("HUD");
        warpBtn = HUDObj.GetComponent<Button>();
        powerLeftTxt = GameObject.Find("PowerLeft").GetComponent<Text>();
        livesLeftTxt = GameObject.Find("LivesLeft").GetComponent<Text>();
        livesLostTxt = GameObject.Find("LivesLost").GetComponent<Text>();
        moraleTxt = GameObject.Find("Morale").GetComponent<Text>();

        setDefaultValues();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
